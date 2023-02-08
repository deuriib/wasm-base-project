using WasmBaseProject.Domain.Dtos;
using WasmBaseProject.Domain.Models;

namespace WasmBaseProject.Domain.Services;

public interface IEmployeeRepository
{
    Task<Employee[]?> GetAllAsync();
    Task<Employee?> GetOneAsync(int id);
    Task<Employee?> CreateAsync(CreateEmployeeDto dto);
    Task<Employee?> UpdateAsync(int id, EditEmployeeDto dto);
    Task<Employee?> UpdateStatusAsync(int id, UpdateEmployeeStatusDto dto);
    Task DeleteAsync(int id);
}