using WasmBaseProject.Domain.Dtos;
using WasmBaseProject.Domain.Services;

namespace WasmBaseProject.Adapters.Services;

public class EmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<EmployeeListDto[]?> GetAllAsync()
    {
        return await _employeeRepository.GetAllAsync();
    }

    public async Task<EditEmployeeDto?> GetOneAsync(int id)
    {
        return await _employeeRepository.GetOneAsync(id);
    }

    public async Task AddOneAsync(CreateEmployeeDto dto)
    {
        await _employeeRepository.AddOneAsync(dto);
    }

    public async Task UpdateAsync(int id, EditEmployeeDto dto)
    {
        await _employeeRepository.UpdateAsync(id, dto); 
    }

    public async Task UpdateStatusAsync(int id, UpdateEmployeeStatusDto dto)
    {
        await _employeeRepository.UpdateStatusAsync(id, dto);
    }

    public async Task DeleteAsync(int id)
    {
        await _employeeRepository.DeleteAsync(id);
    }
}