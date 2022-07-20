using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Store.Employees
{
    public record GetOneEmployeeAction(int Id);
    public record GetOneEmployeeSuccessAction(EmployeeDto? Employee);
    public record GetOneEmployeeFailedAction(string? ErrorMessage);
}
