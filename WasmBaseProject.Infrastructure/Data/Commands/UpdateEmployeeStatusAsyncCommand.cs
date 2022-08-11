using MediatR;
using WasmBaseProject.Domain.Dtos;
using WasmBaseProject.Domain.Services;
using WasmBaseProject.Infrastructure.Data.Events;

namespace WasmBaseProject.Infrastructure.Data.Commands;

public record UpdateEmployeeStatusAsyncCommand(int Id, UpdateEmployeeStatusDto Dto) : IRequest;

public class UpdateEmployeeStatusAsyncCommandHandler : IRequestHandler<UpdateEmployeeStatusAsyncCommand>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMediator _mediator;

    public UpdateEmployeeStatusAsyncCommandHandler(IEmployeeRepository employeeRepository, IMediator mediator)
    {
        _employeeRepository = employeeRepository;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(UpdateEmployeeStatusAsyncCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.UpdateStatusAsync(request.Id, request.Dto);
        
        await _mediator.Publish(new EmployeeStatusUpdatedEvent(employee!.Id, employee!.Status));
        
        return Unit.Value;
    }
}