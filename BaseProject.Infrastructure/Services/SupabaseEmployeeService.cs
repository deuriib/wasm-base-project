using BaseProject.Domain.Enums;
using BaseProject.Domain.Models;
using BaseProject.Domain.Services;
using BaseProject.Infrastructure.Models;
using Postgrest;

namespace BaseProject.Infrastructure.Services;

public sealed class SupabaseEmployeeService : IEmployeeService
{
    private readonly Supabase.Client _client;

    public SupabaseEmployeeService(Supabase.Client client)
    {
        _client = client;
    }

    public async ValueTask<Employee[]?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var response = await _client
            .From<EmployeeModel>()
            .Order("id", Constants.Ordering.Descending)
            .Get(cancellationToken);

        return response
            .Models
            .Select(e => new Employee(e.Id, e.FirstName, e.LastName, e.Email, e.Birthdate)
                .ChangeStatus(EmployeeStatus.FromValue(e.Status)))
            .ToArray();
    }

    public async ValueTask<Employee?> GetOneAsync(int id, CancellationToken cancellationToken = default)
    {
        var model = await _client
            .From<EmployeeModel>()
            .Where(e => e.Id.Equals(id))
            .Single(cancellationToken);

        if (model is null)
            throw new NullReferenceException($"Employee with id {id} not found");

        return new(model.Id, model.FirstName, model.LastName, model.Email, model.Birthdate);
    }

    public async ValueTask<Employee?> CreateAsync(Employee employee, CancellationToken cancellationToken = default)
    {
        var model = new EmployeeModel
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Birthdate = employee.Birthdate,
            Status = employee.Status.Value
        };

        var response = await _client.Postgrest
            .Table<EmployeeModel>()
            .Insert(model,
                new QueryOptions
                {
                    Returning = QueryOptions.ReturnType.Representation
                }, cancellationToken);

        return response.Models
            .Select(e =>
                new Employee(e.Id, e.FirstName, e.LastName, e.Email, e.Birthdate)
                    .ChangeStatus(EmployeeStatus.FromValue(e.Status)))
            .FirstOrDefault();
    }

    public async Task UpdateAsync(int id, Employee employee, CancellationToken cancellationToken = default)
    {
        await _client
            .From<EmployeeModel>()
            .Set(e => e.FirstName, employee.FirstName)
            .Set(e => e.LastName, employee.LastName)
            .Set(e => e.Email, employee.Email)
            .Set(e => e.Birthdate, employee.Birthdate)
            .Set(e => e.Address!, employee.Address)
            .Set(e => e.Note!, employee.Note)
            .Where(e => e.Id.Equals(id))
            .Update(null, cancellationToken);
    }

    public async Task UpdateStatusAsync(int id, Employee employee, CancellationToken cancellationToken = default)
    {
        await _client
            .From<EmployeeModel>()
            .Set(x => x.Status, employee.Status.Value)
            .Where(e => e.Id.Equals(id))
            .Update(null, cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _client
            .From<EmployeeModel>()
            .Where(e => e.Id.Equals(id))
            .Delete(null, cancellationToken);
    }
}