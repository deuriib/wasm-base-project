using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Store.Employees
{
    public record GetOneEmployeeAction(int? Id);
    public record GetOneEmployeeSuccessAction(EditEmployeeDto? Employee);
    public record GetOneEmployeeFailedAction(string? ErrorMessage);
}
