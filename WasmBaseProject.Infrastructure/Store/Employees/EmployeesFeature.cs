using Fluxor;
using WasmBaseProject.Infrastructure.ViewModels;

namespace WasmBaseProject.Infrastructure.Store.Employees;

public class EmployeesFeature : Feature<EmployeesState>
{
    public override string GetName() => "Employees";

    protected override EmployeesState GetInitialState()
        => new EmployeesState(
            IsLoading: true,
            Employees: Array.Empty<EmployeeListViewModel>(),
            SelectedEmployee: new()
        );
}