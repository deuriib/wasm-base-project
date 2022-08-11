using MediatR;

namespace WasmBaseProject.Infrastructure.Data.Events;

public record EmployeeDeletedEvent(int Id) : INotification;

public class EmployeeDeletedEventHandler : INotificationHandler<EmployeeDeletedEvent>
{
    public Task Handle(EmployeeDeletedEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"employee deleted: {notification.Id}");
        return Task.CompletedTask;
    }
}