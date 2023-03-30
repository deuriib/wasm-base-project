using BaseProject.Domain.Dtos;
using BaseProject.Infrastructure.ViewModels;

namespace BaseProject.Infrastructure.Store.Employees;

public record UpdateEmployeeAction(int Id, EmployeeDto Employee);

public record UpdateEmployeeSuccessAction(int Id, EmployeeDto Employee);