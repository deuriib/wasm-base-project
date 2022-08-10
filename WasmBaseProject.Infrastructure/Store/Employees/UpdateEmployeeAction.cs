using WasmBaseProject.Infrastructure.ViewModels;

namespace WasmBaseProject.Infrastructure.Store.Employees;

public record UpdateEmployeeAction(int? Id, EmployeeEditViewModel? Employee);
public record UpdateEmployeeSuccessAction(int? Id, EmployeeEditViewModel? Employee);