using Fluxor;
using WasmBaseProjectApp.Services;
using WasmBaseProjectApp.ViewModels;

namespace WasmBaseProjectApp.Store.Employees;

public static class Reducers
{
    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetEmployeesAction action)
        => state with { IsLoading = true, Employees = Array.Empty<EmployeeListViewModel>() };

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetEmployeesSuccessAction action)
        => state with { IsLoading = false, Employees = action.Employees };

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetEmployeesFailedAction action)
        => state with { IsLoading = false, Employees = Array.Empty<EmployeeListViewModel>() };

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetOneEmployeeAction action)
        => state with { SelectedEmployee = null };

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetOneEmployeeSuccessAction action)
        => state with { SelectedEmployee = action.Employee };

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetOneEmployeeFailedAction action)
        => state with { SelectedEmployee = null };

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, DeleteEmployeeSuccessAction action)
        => state with { Employees = state.Employees?.Where(e => !e.Id.Equals(action.Id)).ToArray() };

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, UpdateEmployeeStatusSuccessAction action)
    {
        var employee = state.Employees?.FirstOrDefault(e => e.Id.Equals(action.Id));
        if (employee == null)
            return state;

        employee = employee with { Status = action.NewStatus };

        var index = Array.FindIndex(state.Employees!, e => e.Id.Equals(action.Id));
        state.Employees?.SetValue(employee, index);

        return state with { Employees = state.Employees };
    }

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, UpdateEmployeeSuccessAction action)
    {
        var employee = state.Employees?.FirstOrDefault(e => e.Id.Equals(action.Id));
        if (employee == null)
            return state;

        employee = employee with
        {
            FullName =$"{action.Employee!.FirstName} {action.Employee!.LastName}",
            BirthDate = $"{action.Employee!.Birthdate!.Value:dd/MM/yyyy}"
        };

        var index = Array.FindIndex(state.Employees!, e => e.Id.Equals(action.Id));
        state.Employees?.SetValue(employee, index);

        return state with { Employees = state.Employees, SelectedEmployee = null };
    }
}