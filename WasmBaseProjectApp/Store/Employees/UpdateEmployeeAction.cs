using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Store.Employees;

public record UpdateEmployeeAction(int? Id, EditEmployeeDto? Employee);
public record UpdateEmployeeSuccessAction(int? Id);
public record UpdateEmployeeFailedAction(string? ErrorMessage);