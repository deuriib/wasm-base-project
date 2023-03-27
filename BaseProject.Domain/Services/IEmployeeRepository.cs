using BaseProject.Domain.Dtos;
using BaseProject.Domain.Models;

namespace BaseProject.Domain.Services;

public interface IEmployeeRepository
{
    Task<Employee[]?> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Employee?> GetOneAsync(int id, CancellationToken cancellationToken = default);
    Task CreateAsync(CreateEmployeeDto dto, CancellationToken cancellationToken = default);
    Task UpdateAsync(int id, EditEmployeeDto dto, CancellationToken cancellationToken = default);
    Task UpdateStatusAsync(int id, UpdateEmployeeStatusDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}