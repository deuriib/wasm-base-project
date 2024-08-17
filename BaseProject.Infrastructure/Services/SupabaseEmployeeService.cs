using BaseProject.Domain.Models;
using BaseProject.Domain.Services;
using Supabase;

namespace BaseProject.Infrastructure.Services;

public sealed class SupabaseEmployeeService(Client supabase) : IEmployeeService
{

    public async ValueTask<IReadOnlyList<Employee>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await supabase.From<Employee>().Get(cancellationToken);

        return result.Models;
    }

    public async ValueTask<Employee?> GetOneAsync(long id, CancellationToken cancellationToken = default)
    {
        return await supabase.From<Employee>()
        .Where(e => e.Id.Equals(id))
        .Single(cancellationToken);
    }

    public async ValueTask<Employee?> CreateAsync(
        Employee employee,
        CancellationToken cancellationToken = default)
    {
        var result = await supabase.From<Employee>()
        .Insert(employee, null, cancellationToken);

        return result.Model;
    }

    public async ValueTask<Employee?> UpdateAsync(
        long id,
        Employee employee,
        CancellationToken cancellationToken = default)
    {
        var result = await supabase.From<Employee>()
        .Where(e => e.Equals(id))
        .Set(e => e.FirstName, employee.FirstName)
        .Set(e => e.LastName, employee.LastName)
        .Set(e => e.Email, employee.Email)
        .Set(e => e.Birthdate, employee.Birthdate)
        .Set(e => e.Address, employee.Address)
        .Set(e => e.Note, employee.Note)
        .Update(null, cancellationToken);

        return result.Model;
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        await supabase.From<Employee>().Delete(null, cancellationToken);
    }

    public async ValueTask<Employee?> UpdateStatusAsync(long id, bool status, CancellationToken cancellationToken = default)
    {
        var result = await supabase.From<Employee>()
        .Where(e => e.Equals(id))
        .Set(e => e.Status, status)
        .Update(null, cancellationToken);

        return result.Model;
    }
}
