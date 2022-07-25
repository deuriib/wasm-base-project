using WasmBaseProjectApp.Services;
using WasmBaseProjectApp.ViewModels;

namespace WasmBaseProjectApp.Store.Employees
{
    public record GetOneEmployeeAction(int? Id);
    public record GetOneEmployeeSuccessAction(EmployeeEditViewModel? Employee);
    public record GetOneEmployeeFailedAction(string? ErrorMessage): EmployeeFailedAction(ErrorMessage);
}
