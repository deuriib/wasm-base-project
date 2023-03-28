using BaseProject.Domain.Dtos;
using BaseProject.Domain.Enums;

namespace BaseProject.Infrastructure.Store.Employees
{
    public record CreateEmployeeAction(CreateEmployeeDto Dto);

    public record CreateEmployeeSuccessAction(int Id,
        string FullName,
        string Email, 
        DateTime Birthdate, 
        EmployeeStatus Status);
}