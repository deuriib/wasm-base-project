namespace WasmBaseProjectApp.Store.Employees;

public record DeleteEmployeeAction(int? Id);

public record DeleteEmployeeSuccessAction(int? Id);

public record DeleteEmployeeFailedAction(string? ErrorMessage);