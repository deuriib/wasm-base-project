using WasmBaseProject.Domain.Dtos;

namespace WasmBaseProject.Infrastructure.Store.Employees
{
    public record CreateEmployeeAction(CreateEmployeeDto? Dto);

    public record CreateEmployeeSuccessAction;
}
