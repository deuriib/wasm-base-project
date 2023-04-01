using BaseProject.Domain.Dtos;
using BaseProject.Domain.Enums;
using BaseProject.Domain.Models;

namespace BaseProject.Infrastructure.Store.Employees
{
    public sealed record CreateEmployeeAction(CreateEmployeeDto Dto);

    public sealed record CreateEmployeeSuccessAction(EmployeeDto Employee);
}