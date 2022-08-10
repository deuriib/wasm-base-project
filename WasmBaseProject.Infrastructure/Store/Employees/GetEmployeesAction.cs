using WasmBaseProject.Infrastructure.ViewModels;

namespace WasmBaseProject.Infrastructure.Store.Employees
{
    public record GetEmployeesAction;

    public record GetEmployeesSuccessAction(EmployeeListViewModel[]? Employees);

    public record GetEmployeesFailedAction(string? ErrorMessage) : EmployeeFailedAction(ErrorMessage);

}
