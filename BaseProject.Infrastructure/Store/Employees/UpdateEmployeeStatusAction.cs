using BaseProject.Domain.Dtos;
using BaseProject.Domain.Enums;

namespace BaseProject.Infrastructure.Store.Employees;

public record UpdateEmployeeStatusAction(int Id);

public record UpdateEmployeeStatusSuccessAction(int Id, EmployeeStatus Status);