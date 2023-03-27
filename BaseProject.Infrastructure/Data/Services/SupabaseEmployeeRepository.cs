using BaseProject.Domain.Dtos;
using BaseProject.Domain.Enums;
using BaseProject.Domain.Models;
using BaseProject.Domain.Services;
using BaseProject.Infrastructure.Data.Models;
using Postgrest;

namespace BaseProject.Infrastructure.Data.Services;

public class SupabaseEmployeeRepository : IEmployeeRepository
{
    private readonly Supabase.Client _client;
    public SupabaseEmployeeRepository(Supabase.Client client)
    {
        _client = client;
    }

    public async Task<Employee[]?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var response = await _client
            .From<EmployeeModel>()
            .Select(x => new object[]{x.Id, x.FirstName, x.LastName, x.Email, x.Birthdate, x.Status})
            .Order("id", Constants.Ordering.Descending)
            .Get(cancellationToken);
        
        response
            .ResponseMessage?
            .EnsureSuccessStatusCode();

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
            .Where(e => e.Id.Equals(id))
            .Single(cancellationToken);
        
        if (employee is null)
            throw new NullReferenceException("Employee not found");
        
        return new (employee.Id, employee.FirstName, employee.LastName, employee.Email, employee.Birthdate);
    }

    public async Task CreateAsync(CreateEmployeeDto dto, CancellationToken cancellationToken = default)
    {
        var model = new EmployeeModel
        {
            FirstName = dto.FirstName!,
            LastName = dto.LastName!,
            Email = dto.Email!,
            Birthdate = dto.Birthdate!.Value
        };
        
        await _client
            .From<EmployeeModel>()
            .Insert(model, null, cancellationToken);
    }

    public async Task UpdateAsync(int id, EditEmployeeDto dto, CancellationToken cancellationToken = default)
    {
        await _client.From<EmployeeModel>()
            .Where(e => e.Id.Equals(id))
            .Set(e => e.FirstName, dto.FirstName)
            .Set(e => e.LastName, dto.LastName)
            .Set(e => e.Email, dto.Email)
            .Set(e => e.Birthdate, dto.Birthdate)
            .Set(e => e.Address!, dto.Address)
            .Set(e => e.Note!, dto.Note)
            .Update(null, cancellationToken);
    }

    public async Task UpdateStatusAsync(int id, UpdateEmployeeStatusDto dto, CancellationToken cancellationToken = default)
    {
        await _client.From<EmployeeModel>()
            .Where(e => e.Id.Equals(id))
            .Set(x => x.Status, !dto.Status.Value)
            .Update(null, cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _client.From<EmployeeModel>()
            .Where(e => e.Id.Equals(id))
            .Delete(null, cancellationToken);
    }
}