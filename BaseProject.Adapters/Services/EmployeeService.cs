using BaseProject.Domain.Dtos;
using BaseProject.Domain.Services;

namespace BaseProject.Adapters.Services;

public class EmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<EmployeeListDto[]?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var employees = await _employeeRepository.GetAllAsync(cancellationToken);

        if (employees is null)
            return Array.Empty<EmployeeListDto>();

        return employees
            .Select(e => 
                new EmployeeListDto(e.Id, $"{e.FirstName} {e.LastName}", e.Email, e.Status, e.Birthdate))
            .ToArray();
    }

    public async Task<EditEmployeeDto?> GetOneAsync(int id, CancellationToken cancellationToken = default)
    {
        var employee = await _employeeRepository.GetOneAsync(id, cancellationToken);
        
        if (employee is null)
            throw new NullReferenceException("Employee not found");

        return new (employee.FirstName, employee.LastName, employee.Email, employee.Address,
            employee.Note, employee.Birthdate);
    }

    public async Task CreateAsync(CreateEmployeeDto dto, CancellationToken cancellationToken = default)
    {
        await _employeeRepository.CreateAsync(dto, cancellationToken);
    }

    public async Task UpdateAsync(int id, EditEmployeeDto dto, CancellationToken cancellationToken = default)
    {
        await _employeeRepository.UpdateAsync(id, dto, cancellationToken);
    }

    public async Task UpdateStatusAsync(int id, UpdateEmployeeStatusDto dto,
        CancellationToken cancellationToken = default)
    {
        await _employeeRepository.UpdateStatusAsync(id, dto, cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _employeeRepository.DeleteAsync(id, cancellationToken);
    }
}