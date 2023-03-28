using BaseProject.Domain.Dtos;
using BaseProject.Domain.Models;

namespace BaseProject.Domain.Services;

public interface IEmployeeService
{
    ValueTask<Employee[]?> GetAllAsync(CancellationToken cancellationToken = default);
    ValueTask<Employee?> GetOneAsync(int id, CancellationToken cancellationToken = default);
    ValueTask<Employee?> CreateAsync(Employee employee, CancellationToken cancellationToken = default);
    Task UpdateAsync(int id, Employee employee, CancellationToken cancellationToken = default);
    Task UpdateStatusAsync(int id, Employee employee, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}