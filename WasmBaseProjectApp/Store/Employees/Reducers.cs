using Fluxor;
using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Store.Employees
{
    public static class Reducers
    {
        [ReducerMethod]
        public static EmployeesState Reduce(EmployeesState state, GetEmployeesAction action)
            => state with { IsLoading = true, Employees = Array.Empty<Employee>(), ErrorMessage = string.Empty };

        [ReducerMethod]
        public static EmployeesState Reduce(EmployeesState state, GetEmployeesSuccessAction action)
            => state with { IsLoading = false, Employees = action.Employees, ErrorMessage = string.Empty };

        [ReducerMethod]
        public static EmployeesState Reduce(EmployeesState state, GetEmployeesFailedAction action)
           => state with { IsLoading = false, Employees = Array.Empty<Employee>(), ErrorMessage = action.ErrorMessage };
    }
}
