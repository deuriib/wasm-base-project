using MediatR;
using WasmBaseProject.Domain.Services;
using WasmBaseProject.Infrastructure.Data.Events;

namespace WasmBaseProject.Infrastructure.Data.Commands;

public record DeleteEmployeeAsyncCommand(int Id) : IRequest;

public class DeleteEmployeeAsyncCommandHandler : IRequestHandler<DeleteEmployeeAsyncCommand>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMediator _mediator;

    public DeleteEmployeeAsyncCommandHandler(IEmployeeRepository employeeRepository, IMediator mediator)
    {
        _employeeRepository = employeeRepository;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(DeleteEmployeeAsyncCommand request, CancellationToken cancellationToken)
    {
        await _employeeRepository.DeleteAsync(request.Id);

        await _mediator.Publish(new EmployeeDeletedEvent(request.Id));
        
        return Unit.Value;
    }
}