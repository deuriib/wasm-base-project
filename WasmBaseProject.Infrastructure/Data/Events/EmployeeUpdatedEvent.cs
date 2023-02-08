using MediatR;

namespace WasmBaseProject.Infrastructure.Data.Events;

public record EmployeeUpdatedEvent(int Id, string FirstName, string LastName, DateTime Birthdate, string? Address,
    string? Note): INotification;

public class EmployeeUpdatedEventHandler : INotificationHandler<EmployeeUpdatedEvent>
{
    public Task Handle(EmployeeUpdatedEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"employee updated: {notification.Id}");
        return Task.CompletedTask;
    }
}