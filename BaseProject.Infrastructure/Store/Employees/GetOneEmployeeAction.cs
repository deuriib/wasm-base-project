using BaseProject.Domain.Dtos;
using BaseProject.Domain.Models;

namespace BaseProject.Infrastructure.Store.Employees;

public sealed record GetOneEmployeeAction(long Id);
    
public sealed record GetOneEmployeeSuccessAction(EmployeeDto Employee);
    
public sealed record GetOneEmployeeFailedAction(string ErrorMessage);