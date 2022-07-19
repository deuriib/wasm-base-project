using Fluxor;
using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Store.Employees
{
    public static class Reducers
    {
        [ReducerMethod]
        public static EmployeesState Reduce(EmployeesState state, GetEmployeesAction action)
            => state with { IsLoading = true, Employees = null};

        [ReducerMethod]
        public static EmployeesState Reduce(EmployeesState state, GetEmployeesSuccessAction action)
            => state with { IsLoading = false, Employees = action.Employees };

        [ReducerMethod]
        public static EmployeesState Reduce(EmployeesState state, GetEmployeesFailedAction action)
           => state with { IsLoading = false, Employees = null, ErrorMessage = action.ErrorMessage};

        [ReducerMethod]
        public static EmployeesState Reduce(EmployeesState state, UpdateEmployeeStatusAction action)
            => state with { };

        [ReducerMethod]
        public static EmployeesState Reduce(EmployeesState state, UpdateEmployeeStatusSuccessAction action)
            => state with { };

        [ReducerMethod]
        public static EmployeesState Reduce(EmployeesState state, UpdateEmployeeStatusFailedAction action)
            => state with { ErrorMessage = action.ErrorMessage};
        
        [ReducerMethod]
        public static EmployeesState Reduce(EmployeesState state, DeleteEmployeeAction action)
            => state with { };

        [ReducerMethod]
        public static EmployeesState Reduce(EmployeesState state, DeleteEmployeeSuccessAction action)
            => state with { };

        [ReducerMethod]
        public static EmployeesState Reduce(EmployeesState state, DeleteEmployeeFailedAction action)
            => state with { ErrorMessage = action.ErrorMessage};
    }
}
