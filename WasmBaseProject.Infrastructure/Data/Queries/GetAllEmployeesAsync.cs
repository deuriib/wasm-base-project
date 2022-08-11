using MediatR;
using WasmBaseProject.Domain.Models;
using WasmBaseProject.Domain.Services;

namespace WasmBaseProject.Infrastructure.Data.Queries;

public record GetAllEmployeesAsync :IRequest<Employee[]?>;

public class GetAllEmployeesAsyncHandler : IRequestHandler<GetAllEmployeesAsync, Employee[]?>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetAllEmployeesAsyncHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Employee[]?> Handle(GetAllEmployeesAsync request, CancellationToken cancellationToken)
    {
        return await _employeeRepository.GetAllAsync();
    }
}