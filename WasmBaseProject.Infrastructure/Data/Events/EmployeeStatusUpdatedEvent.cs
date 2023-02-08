using MediatR;
using WasmBaseProject.Domain.Enums;

namespace WasmBaseProject.Infrastructure.Data.Events;

public record EmployeeStatusUpdatedEvent(int Id, EmployeeStatus Status) : INotification;

public class EmployeeStatusUpdatedEventHandler : INotificationHandler<EmployeeStatusUpdatedEvent>
{
    public Task Handle(EmployeeStatusUpdatedEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"employee status updated: {notification.Id}");
        return Task.CompletedTask;
    }
}