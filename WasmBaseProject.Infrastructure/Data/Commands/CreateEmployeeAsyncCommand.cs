using AutoMapper;
using MediatR;
using WasmBaseProject.Domain.Dtos;
using WasmBaseProject.Domain.Services;
using WasmBaseProject.Infrastructure.Data.Events;

namespace WasmBaseProject.Infrastructure.Data.Commands;

public record CreateEmployeeAsyncCommand(CreateEmployeeDto Dto) : IRequest;

public class CreateEmployeeAsyncCommandHandler : IRequestHandler<CreateEmployeeAsyncCommand>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMediator _mediator;

    public CreateEmployeeAsyncCommandHandler(IEmployeeRepository employeeRepository, IMediator mediator)
    {
        _employeeRepository = employeeRepository;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(CreateEmployeeAsyncCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.CreateAsync(request.Dto);

        await _mediator.Publish(new EmployeeCreatedEvent(employee!.Id, employee.FirstName, employee.LastName,
            employee.Birthdate, employee.Address, employee.Note));

        return Unit.Value;
    }
}