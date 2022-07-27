using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using Supabase.Realtime;
using WasmBaseProjectApp.Data.Models;
using WasmBaseProjectApp.Data.Repositories;
using WasmBaseProjectApp.ViewModels;
using Ardalis.SmartEnum;

namespace WasmBaseProjectApp.Services;

public class EmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<EmployeeListViewModel[]> GetAllAsync()
    {
        var dto = await _employeeRepository.GetAllAsync();
        var viewmodel = dto.Select(e
            => new EmployeeListViewModel
            {
                Id = e.Id, FullName = $"{e.FirstName} {e.LastName}", Status = e.Status,
                BirthDate = $"{e.Birthdate:dd/MM/yyyy}"
            }).ToArray();
        return viewmodel;
    }

    public async Task<EmployeeEditViewModel?> GetOneAsync(int id)
    {
        var employee = await _employeeRepository.GetOneAsync(id);
        return new EmployeeEditViewModel
        {
            Address = employee.Address,
            Birthdate = employee.Birthdate,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Note = employee.Note
        };
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

public record EditEmployeeDto(string? FirstName, string? LastName, string? Address, string? Note, DateTime? Birthdate);

public record UpdateEmployeeStatusDto
{
    [JsonPropertyName("status")] public EmployeeStatus? Status { get; set; }
}

public record EmployeeListDto
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public EmployeeStatus? Status { get; set; }

    public DateTime Birthdate { get; set; }
}

public record CreateEmployeeDto
{
    [JsonPropertyName("name")] public string? FirstName { get; set; }

    [JsonPropertyName("last_name")] public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? Note { get; set; }

    [JsonPropertyName("birth_date")] public DateTime? Birthdate { get; set; }
};

public abstract class EmployeeStatus : SmartEnum<EmployeeStatus, bool>
{
    public static readonly EmployeeStatus Inactive = new InactiveStatus();
    public static readonly EmployeeStatus Active = new ActiveStatus();

    private EmployeeStatus(string name, bool value) : base(name, value)
    {
    }


    private sealed class InactiveStatus : EmployeeStatus
    {
        public InactiveStatus() : base("Inactive", false)
        {
        }
    }

    private sealed class ActiveStatus : EmployeeStatus
    {
        public ActiveStatus() : base("Active", true)
        {
        }
    }
}