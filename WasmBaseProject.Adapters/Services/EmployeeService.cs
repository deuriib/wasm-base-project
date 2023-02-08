using AutoMapper;
using MediatR;
using WasmBaseProject.Domain.Dtos;
using WasmBaseProject.Infrastructure.Data.Commands;
using WasmBaseProject.Infrastructure.Data.Queries;

namespace WasmBaseProject.Adapters.Services;

public class EmployeeService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public EmployeeService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<EmployeeListDto[]?> GetAllAsync()
    {
        var employees = await _mediator.Send(new GetAllEmployeesAsync());

        return _mapper.Map<EmployeeListDto[]>(employees);
    }

    public async Task<EditEmployeeDto?> GetOneAsync(int id)
    {
        var employee = await _mediator.Send(new GetOneEmployeeAsync(id));

        return _mapper.Map<EditEmployeeDto>(employee);
    }

    public async Task CreateAsync(CreateEmployeeDto dto)
    {
        await _mediator.Send(new CreateEmployeeAsyncCommand(dto));
    }

    public async Task UpdateAsync(int id, EditEmployeeDto dto)
    {
        await _mediator.Send(new UpdateEmployeeAsyncCommand(id, dto));
    }

    public async Task UpdateStatusAsync(int id, UpdateEmployeeStatusDto dto)
    {
        await _mediator.Send(new UpdateEmployeeStatusAsyncCommand(id, dto));
    }

    public async Task DeleteAsync(int id)
    {
        await _mediator.Send(new DeleteEmployeeAsyncCommand(id));
    }
}