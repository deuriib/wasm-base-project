using BaseProject.Domain.Dtos;
using BaseProject.Infrastructure.ViewModels;

namespace BaseProject.Infrastructure.Store.Employees;

public record GetOneEmployeeAction(int? Id);
    
public record GetOneEmployeeSuccessAction(UpdateEmployeeDto? Employee);
    
public record GetOneEmployeeFailedAction(string ErrorMessage);