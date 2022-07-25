using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Data.Repositories;

public interface IEmployeeRepository
{
    Task<EmployeeListDto[]> GetAllAsync();
    Task<EditEmployeeDto> GetOneAsync(int id);
    Task AddOneAsync(CreateEmployeeDto dto);
    Task UpdateAsync(int id, EditEmployeeDto dto);
    Task UpdateStatusAsync(int id, UpdateEmployeeStatusDto dto);
    Task DeleteAsync(int id);
}