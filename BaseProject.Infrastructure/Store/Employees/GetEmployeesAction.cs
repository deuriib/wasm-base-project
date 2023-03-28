using BaseProject.Domain.Dtos;
using BaseProject.Infrastructure.ViewModels;

namespace BaseProject.Infrastructure.Store.Employees;

public record GetEmployeesAction;

public record GetEmployeesSuccessAction(ListEmployeeDto[] Employees);

public record GetEmployeesFailedAction(string ErrorMessage);