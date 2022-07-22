using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Store.Employees
{
    public record CreateEmployeeAction(CreateEmployeeDto? Dto);
    public record CreateEmployeeSuccessAction();
    public record CreateEmployeeFailedAction(string? ErrorMessage);
}
