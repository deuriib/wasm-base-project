using BaseProject.Domain.Dtos;

namespace BaseProject.Infrastructure.Store.Employees;

public record GetOneEmployeeAction(int Id);
    
public record GetOneEmployeeSuccessAction(EmployeeDto Employee);
    
public record GetOneEmployeeFailedAction(string ErrorMessage);