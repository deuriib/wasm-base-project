namespace WasmBaseProjectApp.Store.Employees;

public record UpdateEmployeeStatusAction(int Id, bool CurrentStatus);

public record UpdateEmployeeStatusSuccessAction(int Id);
