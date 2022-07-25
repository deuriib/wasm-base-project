using WasmBaseProjectApp.Services;
using WasmBaseProjectApp.ViewModels;

namespace WasmBaseProjectApp.Store.Employees
{
    public record GetEmployeesAction;

    public record GetEmployeesSuccessAction(EmployeeListViewModel[]? Employees);

    public record GetEmployeesFailedAction(string? ErrorMessage) : EmployeeFailedAction(ErrorMessage);

}
