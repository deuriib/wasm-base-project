using MediatR;

namespace WasmBaseProject.Infrastructure.Data.Events;

public record EmployeeCreatedEvent(int Id, string FirstName, string LastName, DateTime Birthdate, string? Address,
    string? Note) : INotification;

public class EmployeeCreatedEventHandler : INotificationHandler<EmployeeCreatedEvent>
{
    public Task Handle(EmployeeCreatedEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"employee created: {notification.Id}");
        return Task.CompletedTask;
    }
}