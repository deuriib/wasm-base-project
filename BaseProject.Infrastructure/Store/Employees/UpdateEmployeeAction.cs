using BaseProject.Domain.Dtos;
using BaseProject.Infrastructure.ViewModels;

namespace BaseProject.Infrastructure.Store.Employees;

public sealed record UpdateEmployeeAction(long EmployeeId, EmployeeDto Employee);

public sealed record UpdateEmployeeSuccessAction(long EmployeeId, EmployeeDto Employee);