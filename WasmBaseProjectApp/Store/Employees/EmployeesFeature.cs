using Fluxor;
using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Store.Employees
{
    public class EmployeesFeature : Feature<EmployeesState>
    {
        public override string GetName() => "Employees";

        protected override EmployeesState GetInitialState()
            => new EmployeesState(
                IsLoading: true,
                Employees: Array.Empty<Employee>()
            );
    }
}
