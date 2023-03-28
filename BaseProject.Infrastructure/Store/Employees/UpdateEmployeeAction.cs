using BaseProject.Domain.Dtos;
using BaseProject.Infrastructure.ViewModels;

namespace BaseProject.Infrastructure.Store.Employees;

public record UpdateEmployeeAction(int Id, UpdateEmployeeDto UpdateEmployee);

public record UpdateEmployeeSuccessAction(int Id, UpdateEmployeeDto Employee);