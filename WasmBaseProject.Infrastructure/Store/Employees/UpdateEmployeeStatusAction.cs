using WasmBaseProject.Domain.Dtos;
using WasmBaseProject.Domain.Enums;

namespace WasmBaseProject.Infrastructure.Store.Employees;

public record UpdateEmployeeStatusAction(int? Id, UpdateEmployeeStatusDto? Dto);

public record UpdateEmployeeStatusSuccessAction(int? Id, EmployeeStatus? Status);
