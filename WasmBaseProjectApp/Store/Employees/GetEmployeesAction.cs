using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Store.Employees
{
    public record GetEmployeesAction();

    public record GetEmployeesSuccessAction(EmployeeListDto[]? Employees);

    public record GetEmployeesFailedAction(string? ErrorMessage) : EmployeeFailedAction(ErrorMessage);

}
