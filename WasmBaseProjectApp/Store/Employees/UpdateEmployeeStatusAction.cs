using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Store.Employees;

public record UpdateEmployeeStatusAction(int? Id, UpdateEmployeeStatusDto? Dto);

public record UpdateEmployeeStatusSuccessAction(int? Id, bool NewStatus);
