using MediatR;
using WasmBaseProject.Domain.Models;
using WasmBaseProject.Domain.Services;

namespace WasmBaseProject.Infrastructure.Data.Queries;

public record GetOneEmployeeAsync(int Id) : IRequest<Employee?>;

public class GetOneEmployeeAsyncHandler : IRequestHandler<GetOneEmployeeAsync, Employee?>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetOneEmployeeAsyncHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Employee?> Handle(GetOneEmployeeAsync request, CancellationToken cancellationToken)
    {
        return await _employeeRepository.GetOneAsync(request.Id);
    }
}