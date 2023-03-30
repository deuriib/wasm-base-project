using BaseProject.Domain.Dtos;
using BaseProject.Domain.Enums;

namespace BaseProject.Infrastructure.Store.Employees
{
    public sealed record CreateEmployeeAction(CreateEmployeeDto Dto);

    public sealed record CreateEmployeeSuccessAction(int Id,
        string FullName,
        string Email, 
        DateTime Birthdate, 
        EmployeeStatus Status);
}