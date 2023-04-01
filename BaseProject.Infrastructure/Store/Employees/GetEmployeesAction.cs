using BaseProject.Domain.Dtos;

namespace BaseProject.Infrastructure.Store.Employees;

public sealed record GetEmployeesAction;

public sealed record GetEmployeesSuccessAction(EmployeeDto[] Employees);

public sealed record GetEmployeesFailedAction(string ErrorMessage);