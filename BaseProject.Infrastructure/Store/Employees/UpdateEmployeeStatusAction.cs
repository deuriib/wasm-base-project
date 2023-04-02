using BaseProject.Domain.Dtos;
using BaseProject.Domain.Enums;

namespace BaseProject.Infrastructure.Store.Employees;

public sealed record UpdateEmployeeStatusAction(long Id);

public sealed record UpdateEmployeeStatusSuccessAction(long Id, EmployeeStatus Status);