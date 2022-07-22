using Fluxor;
using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Store.Employees;

public static class Reducers
{
    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetEmployeesAction action)
        => state with { IsLoading = true, Employees = Array.Empty<EmployeeListDto>() };

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetEmployeesSuccessAction action)
        => state with { IsLoading = false, Employees = action.Employees };

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetEmployeesFailedAction action)
        => state with { IsLoading = false, Employees = Array.Empty<EmployeeListDto>() };

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetOneEmployeeAction action)
        => state with { SelectedEmployee = null };

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetOneEmployeeSuccessAction action)
        => state with { SelectedEmployee = action.Employee };

    [ReducerMethod]
    public static EmployeesState Reduce(EmployeesState state, GetOneEmployeeFailedAction action)
        => state with { SelectedEmployee = null };
}