using BaseProject.Domain.Dtos;
using BaseProject.Domain.Models;

namespace BaseProject.Domain.Services;

public interface IEmployeeService
{
    Task<Employee[]?> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Employee?> GetOneAsync(int id, CancellationToken cancellationToken = default);
    Task CreateAsync(Employee employee, CancellationToken cancellationToken = default);
    Task UpdateAsync(int id, Employee employee, CancellationToken cancellationToken = default);
    Task UpdateStatusAsync(int id, Employee employee, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}