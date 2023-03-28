using BaseProject.Domain.Dtos;
using BaseProject.Domain.Enums;
using BaseProject.Domain.Models;
using BaseProject.Domain.Services;
using BaseProject.Infrastructure.Data.Models;
using Postgrest;

namespace BaseProject.Infrastructure.Data.Services;

public class SupabaseEmployeeService : IEmployeeService
{
    private readonly Supabase.Client _client;
    public SupabaseEmployeeService(Supabase.Client client)
    {
        _client = client;
    }

    public async Task<Employee[]?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var response = await _client
            .From<EmployeeModel>()
            .Select(x => new object[]{x.Id, x.FirstName, x.LastName, x.Email, x.Birthdate, x.Status})
            .Filter("user_id",Constants.Operator.Equals, _client.Auth.CurrentUser!.Id!)
            .Order("id", Constants.Ordering.Descending)
            .Get(cancellationToken);

        return response
            .Models
            .Select(e => new Employee(e.Id, e.FirstName, e.LastName, e.Email, e.Birthdate)
                .ChangeStatus(EmployeeStatus.FromValue(e.Status)))
            .ToArray();
    }

    public async Task<Employee?> GetOneAsync(int id, CancellationToken cancellationToken = default)
    {
        var employee = await _client
            .From<EmployeeModel>()
            .Select(x => new object[]{x.Id, x.FirstName, x.LastName, x.Email, x.Birthdate})
            .Filter("user_id",Constants.Operator.Equals, _client.Auth.CurrentUser!.Id!)
            .Where(e => e.Id.Equals(id))
            .Single(cancellationToken);
        
        if (employee is null)
            throw new NullReferenceException("Employee not found");
        
        return new (employee.Id, employee.FirstName, employee.LastName, employee.Email, employee.Birthdate);
    }

    public async Task CreateAsync(Employee employee, CancellationToken cancellationToken = default)
    {
        var model = new EmployeeModel
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Birthdate = employee.Birthdate,
            Status = employee.Status.Value,
            UserId = Guid.Parse(_client.Auth.CurrentUser!.Id!)
        };
        
        await _client
            .From<EmployeeModel>()
            .Insert(model, null, cancellationToken);
    }

    public async Task UpdateAsync(int id, Employee employee, CancellationToken cancellationToken = default)
    {
        await _client
            .From<EmployeeModel>()
            .Where(e => e.Id.Equals(id))
            .Set(e => e.FirstName, employee.FirstName)
            .Set(e => e.LastName, employee.LastName)
            .Set(e => e.Email, employee.Email)
            .Set(e => e.Birthdate, employee.Birthdate)
            .Set(e => e.Address!, employee.Address)
            .Set(e => e.Note!, employee.Note)
            .Filter("user_id",Constants.Operator.Equals, _client.Auth.CurrentUser!.Id!)
            .Update(null, cancellationToken);
    }

    public async Task UpdateStatusAsync(int id, Employee employee, CancellationToken cancellationToken = default)
    {
        await _client
            .From<EmployeeModel>()
            .Where(e => e.Id.Equals(id))
            .Set(x => x.Status, employee.Status.Value)
            .Filter("user_id",Constants.Operator.Equals, _client.Auth.CurrentUser!.Id!)
            .Update(null, cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _client
            .From<EmployeeModel>()
            .Where(e => e.Id.Equals(id))
            .Filter("user_id",Constants.Operator.Equals, _client.Auth.CurrentUser!.Id!)
            .Delete(null, cancellationToken);
    }
}