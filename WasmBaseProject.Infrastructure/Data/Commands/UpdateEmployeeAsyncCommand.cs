using MediatR;
using WasmBaseProject.Domain.Dtos;
using WasmBaseProject.Domain.Services;
using WasmBaseProject.Infrastructure.Data.Events;

namespace WasmBaseProject.Infrastructure.Data.Commands;

public record UpdateEmployeeAsyncCommand(int Id, EditEmployeeDto Dto): IRequest;

public class UpdateEmployeeAsyncCommandHandler : IRequestHandler<UpdateEmployeeAsyncCommand>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMediator _mediator;

    public UpdateEmployeeAsyncCommandHandler(IEmployeeRepository employeeRepository, IMediator mediator)
    {
        _employeeRepository = employeeRepository;
        _mediator = mediator;
    }
    
    public async Task<Unit> Handle(UpdateEmployeeAsyncCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.UpdateAsync(request.Id, request.Dto);
        
        await _mediator.Publish(new EmployeeUpdatedEvent(employee!.Id, employee.FirstName, employee.LastName,
            employee.Birthdate, employee.Address, employee.Note));
        
        return Unit.Value;
    }
}