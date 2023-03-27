using BaseProject.Infrastructure.Store.Employees;
using BaseProject.Infrastructure.ViewModels;
using Fluxor;

namespace BaseProject.Adapters.Store.Reducers;

public static class EmployeeReducers
{
    [ReducerMethod(typeof(GetEmployeesAction))]
    public static EmployeesState Reduce(EmployeesState state)
        => new(isLoading: true, employees: Array.Empty<EmployeeListViewModel>(), selectedEmployee: null,
            isLoadingEmployee: false);

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetEmployeesSuccessAction action)
        => new(isLoading: false, employees: action.Employees, selectedEmployee: null, isLoadingEmployee: false);

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetEmployeesFailedAction action)
        => new(isLoading: false, employees: Array.Empty<EmployeeListViewModel>(), selectedEmployee: null,
            isLoadingEmployee: false);

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetOneEmployeeAction action)
        => new(isLoading: false, employees: state.Employees, selectedEmployee: null,
            isLoadingEmployee: true);

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetOneEmployeeSuccessAction action)
        => new(isLoading: false, employees: state.Employees, selectedEmployee: action.Employee,
            isLoadingEmployee: false);

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetOneEmployeeFailedAction action)
        => new(isLoading: false, employees: state.Employees, selectedEmployee: null,
            isLoadingEmployee: false);

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, DeleteEmployeeSuccessAction action)
        => new(isLoading: false, 
            employees: state.Employees
                .Where(e => !e.Id.Equals(action.Id))
                .ToArray(),
            selectedEmployee: null,
            isLoadingEmployee: false);

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, UpdateEmployeeStatusSuccessAction action)
    {
        var employee = state.Employees.FirstOrDefault(e => e.Id.Equals(action.Id));
        if (employee is null)
            return state;

        employee = employee with { Status = action.Status! };

        var index = Array.FindIndex(state.Employees, e => e.Id.Equals(action.Id));
        state.Employees.SetValue(employee, index);

        return new (isLoading: false, employees: state.Employees, selectedEmployee: state.SelectedEmployee,
            isLoadingEmployee: false);
    }

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, UpdateEmployeeSuccessAction action)
    {
        var employee = state.Employees.FirstOrDefault(e => e.Id.Equals(action.Id));
        if (employee is null)
            return state;

        employee = employee with
        {
            FullName = $"{action.Employee!.FirstName} {action.Employee!.LastName}",
            Email = action.Employee!.Email!,
            Birthdate = $"{action.Employee!.Birthdate!.Value:dd/MM/yyyy}"
        };

        var index = Array.FindIndex(state.Employees, e => e.Id.Equals(action.Id));
        state.Employees.SetValue(employee, index);

        return new (isLoading: false, employees: state.Employees, selectedEmployee: state.SelectedEmployee,
            isLoadingEmployee: false);
    }
}