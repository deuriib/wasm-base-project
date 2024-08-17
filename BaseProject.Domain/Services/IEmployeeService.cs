using BaseProject.Domain.Dtos;
using BaseProject.Domain.Models;

namespace BaseProject.Domain.Services;

public interface IEmployeeService : IService
{
    ValueTask<IReadOnlyList<Employee>?> GetAllAsync(CancellationToken cancellationToken = default);
    ValueTask<Employee?> GetOneAsync(long id, CancellationToken cancellationToken = default);
    ValueTask<Employee?> CreateAsync(Employee employee, CancellationToken cancellationToken = default);
    ValueTask<Employee?> UpdateAsync(long id, Employee employee, CancellationToken cancellationToken = default);
    ValueTask<Employee?> UpdateStatusAsync(long id, bool status, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}