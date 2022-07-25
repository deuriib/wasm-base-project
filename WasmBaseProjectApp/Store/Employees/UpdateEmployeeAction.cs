using WasmBaseProjectApp.Services;
using WasmBaseProjectApp.ViewModels;

namespace WasmBaseProjectApp.Store.Employees;

public record UpdateEmployeeAction(int? Id, EmployeeEditViewModel? Employee);
public record UpdateEmployeeSuccessAction(int? Id, EmployeeEditViewModel? Employee);