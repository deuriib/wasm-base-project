using BaseProject.Domain.Dtos;
using BaseProject.Infrastructure.Store.Employees;
using Fluxor;

namespace BaseProject.Adapters.Reducers;

public static class EmployeeReducers
{
    [ReducerMethod(typeof(GetEmployeesAction))]
    public static EmployeesState OnGetEmployeesAction(EmployeesState state)
        => state with
        {
            IsLoading = true,
            Employees = Array.Empty<EmployeeDto>()
        };

    [ReducerMethod]
    public static EmployeesState OnGetEmployeesSuccessAction(EmployeesState state, GetEmployeesSuccessAction action)
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
            Employees = Array.Empty<EmployeeDto>(),
            ErrorMessage = action.ErrorMessage
        };

    [ReducerMethod(typeof(GetOneEmployeeAction))]
    public static EmployeesState OnGetOneEmployeeAction(EmployeesState state)
        => state with
        {
            IsLoadingEmployee = true,
            SelectedEmployee = null
        };

    [ReducerMethod]
    public static EmployeesState OnGetOneEmployeeSuccessAction(EmployeesState state, 
        GetOneEmployeeSuccessAction action)
        => state with
        {
            IsLoadingEmployee = false,
            SelectedEmployee = action.Employee
        };

    [ReducerMethod]
    public static EmployeesState OnGetOneEmployeeFailedAction(EmployeesState state, 
        GetOneEmployeeFailedAction action)
        => state with
        {
            IsLoadingEmployee = false,
            SelectedEmployee = null,
            ErrorMessage = action.ErrorMessage
        };

    [ReducerMethod]
    public static EmployeesState OnCreateEmployeeSuccessAction(EmployeesState state, 
        CreateEmployeeSuccessAction action)
    {
        return state with
        {
            Employees = state.Employees
                .Append(action.Employee)
                .OrderByDescending(c => c.Id)
                .ToArray()
        };
    }

    [ReducerMethod]
    public static EmployeesState OnDeleteEmployeeSuccessAction(EmployeesState state, 
        DeleteEmployeeSuccessAction action)
        => state with
        {
            Employees = state.Employees
                .Where(e => !e.Id.Equals(action.Id))
                .ToArray()
        };

    [ReducerMethod]
    public static EmployeesState OnUpdateEmployeeStatusSuccessAction(EmployeesState state, 
        UpdateEmployeeStatusSuccessAction action)
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

        return state;
    }

    [ReducerMethod]
    public static EmployeesState OnUpdateEmployeeSuccessAction(EmployeesState state, UpdateEmployeeSuccessAction action)
    {
        var employee = state
            .Employees
            .FirstOrDefault(e =>
                e.Id.Equals(action.EmployeeId));

        if (employee is null)
            return state;

        employee = employee with
        {
            FirstName = $"{action.Employee.FirstName}",
            LastName = $"{action.Employee.LastName}",
            Email = action.Employee.Email!
        };

        var index = Array
            .FindIndex(state.Employees, e =>
                e.Id.Equals(action.EmployeeId));

        state
            .Employees
            .SetValue(employee, index);

        return state;
    }

    [ReducerMethod(typeof(OpenCreateEmployeeModalAction))]
    public static EmployeesState OnOpenCreateEmployeeModalAction(EmployeesState state)
        => state with
        {
            IsCreateEmployeeModalOpen = true
        };

    [ReducerMethod(typeof(CloseCreateEmployeeAction))]
    public static EmployeesState OnCloseCreateEmployeeAction(EmployeesState state)
        => state with
        {
            IsCreateEmployeeModalOpen = false
        };
    
    [ReducerMethod(typeof(OpenDeleteEmployeeModalAction))]
    public static EmployeesState OnOpenDeleteEmployeeModalAction(EmployeesState state)
        => state with
        {
            IsDeleteEmployeeModalOpen = true
        };

    [ReducerMethod(typeof(CloseDeleteEmployeeModelAction))]
    public static EmployeesState OnCloseDeleteEmployeeModelAction(EmployeesState state)
        => state with
        {
            IsDeleteEmployeeModalOpen = false
        };
    
    [ReducerMethod(typeof(OpenDetailsEmployeeModal))]
    public static EmployeesState OnOpenDetailsEmployeeModalAction(EmployeesState state)
        => state with
        {
            IsDetailsEmployeeModalOpen = true
        };

    [ReducerMethod(typeof(CloseDetailsEmployeeModal))]
    public static EmployeesState OnCloseDetailsEmployeeModelAction(EmployeesState state)
        => state with
        {
            IsDetailsEmployeeModalOpen = false
        };
    
    [ReducerMethod(typeof(OpenEditEmployeeModal))]
    public static EmployeesState OnOpenEditEmployeeModalAction(EmployeesState state)
        => state with
        {
            IsEditEmployeeModalOpen = true
        };

    [ReducerMethod(typeof(CloseEditEmployeeModal))]
    public static EmployeesState OnCloseEditEmployeeModelAction(EmployeesState state)
        => state with
        {
            IsEditEmployeeModalOpen = false
        };
}