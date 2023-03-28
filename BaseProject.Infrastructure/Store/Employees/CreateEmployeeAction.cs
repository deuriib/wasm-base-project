using BaseProject.Domain.Dtos;

namespace BaseProject.Infrastructure.Store.Employees
{
    public record CreateEmployeeAction(CreateEmployeeDto Dto);

    public record CreateEmployeeSuccessAction;
}