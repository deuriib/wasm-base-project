using BaseProject.Domain.Dtos;
using BaseProject.Infrastructure.Store.Employees;
using BaseProject.Infrastructure.ViewModels;
using Fluxor;

namespace BaseProject.Adapters.Reducers;

public static class EmployeeReducers
{
    [ReducerMethod(typeof(GetEmployeesAction))]
    public static EmployeesState Reduce(EmployeesState state)
        => state with
        {
            IsLoading = true,
            Employees = Array.Empty<ListEmployeeDto>()
        };

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetEmployeesSuccessAction action)
        => state with
        {
            IsLoading = false,
            Employees = action.Employees
        };

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetEmployeesFailedAction action)
        => state with
        {
            IsLoading = false,
            Employees = Array.Empty<ListEmployeeDto>(),
            ErrorMessage = action.ErrorMessage
        };

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetOneEmployeeAction action)
        => state with
        {
            IsLoadingEmployee = true,
            SelectedEmployee = null
        };

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetOneEmployeeSuccessAction action)
        => state with
        {
            IsLoadingEmployee = false,
            SelectedEmployee = action.Employee
        };

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetOneEmployeeFailedAction action)
        => state with
        {
            IsLoadingEmployee = false,
            SelectedEmployee = null,
            ErrorMessage = action.ErrorMessage
        };

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, CreateEmployeeSuccessAction action)
    {
        var employee = new ListEmployeeDto(action.Id,
            action.FullName,
            action.Email,
            action.Status
        );

        return state with
        {
            Employees = state.Employees
                .Append(employee)
                .OrderByDescending(c => c.Id)
                .ToArray()
        };
    }

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, DeleteEmployeeSuccessAction action)
        => state with
        {
            Employees = state.Employees
                .Where(e => !e.Id.Equals(action.Id))
                .ToArray()
        };

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, UpdateEmployeeStatusSuccessAction action)
    {
        var employee = state
            .Employees
            .FirstOrDefault(e =>
                e.Id.Equals(action.Id));

        if (employee is null)
            return state;

        employee = employee with { Status = action.Status };

        var index = Array
            .FindIndex(state.Employees, e =>
                e.Id.Equals(action.Id));

        state
            .Employees
            .SetValue(employee, index);

        return state with
        {
            Employees = state.Employees
        };
    }

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, UpdateEmployeeSuccessAction action)
    {
        var employee = state
            .Employees
            .FirstOrDefault(e =>
                e.Id.Equals(action.Id));

        if (employee is null)
            return state;

        employee = employee with
        {
            FullName = $"{action.Employee.FirstName} {action.Employee.LastName}",
            Email = action.Employee.Email!
        };

        var index = Array
            .FindIndex(state.Employees, e =>
                e.Id.Equals(action.Id));

        state
            .Employees
            .SetValue(employee, index);

        return state with
        {
            Employees = state.Employees
        };
    }

    [ReducerMethod(typeof(OpenCreateEmployeeModalAction))]
    public static EmployeesState OpenCreateEmployeeModal(EmployeesState state)
        => state with
        {
            IsCreateEmployeeModalOpen = true
        };

    [ReducerMethod(typeof(CloseCreateEmployeeAction))]
    public static EmployeesState CloseCreateEmployeeModal(EmployeesState state)
        => state with
        {
            IsCreateEmployeeModalOpen = false
        };
    
    [ReducerMethod(typeof(OpenDeleteEmployeeModalAction))]
    public static EmployeesState OpenDeleteEmployeeModal(EmployeesState state)
        => state with
        {
            IsDeleteEmployeeModalOpen = true
        };

    [ReducerMethod(typeof(CloseDeleteEmployeeModelAction))]
    public static EmployeesState CloseDeleteEmployeeModal(EmployeesState state)
        => state with
        {
            IsDeleteEmployeeModalOpen = false
        };
}