using Postgrest;
using WasmBaseProjectApp.Data.Models;
using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Data.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly Supabase.Client _client;

    public EmployeeRepository()
    {
        _client = Supabase.Client.Instance;
    }

    public async Task<EmployeeListDto[]> GetAllAsync()
    {
        var channel = await _client.From<EmployeeModel>().Get();
        channel.ResponseMessage.EnsureSuccessStatusCode();

        var employees = channel.Models.Select(e => new EmployeeListDto
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Birthdate = e.Birthdate!.Value,
            Status = EmployeeStatus.FromValue(e.Status)
        }).ToArray();
        return employees;
    }

    public async Task<EditEmployeeDto> GetOneAsync(int id)
    {
        var channel = await _client.From<EmployeeModel>().Get();

        var employee = channel.Models.Find(e => e.Id.Equals(id));
        return new EditEmployeeDto(employee?.FirstName, employee?.LastName, employee?.Address, employee?.Note,
            employee?.Birthdate);
    }

    public async Task AddOneAsync(CreateEmployeeDto dto)
    {
        var response = await _client.From<EmployeeModel>().Insert(
            new EmployeeModel
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Address = dto.Address,
                Note = dto.Note,
                Birthdate = dto.Birthdate
            });
        
        response.ResponseMessage.EnsureSuccessStatusCode();
    }

    public async Task UpdateAsync(int id, EditEmployeeDto dto)
    {
        var response = await _client.From<EmployeeModel>().Get();
        var employee = response.Models.Find(e => e.Id.Equals(id));

        if (employee is null)
            throw new ArgumentException($"Employee with id {id} not found");

        employee.FirstName = dto.FirstName;
        employee.LastName = dto.LastName;
        employee.Address = dto.Address;
        employee.Note = dto.Note;
        employee.Birthdate = dto.Birthdate;

        await employee.Update<EmployeeModel>();

        response.ResponseMessage.EnsureSuccessStatusCode();
    }

    public async Task UpdateStatusAsync(int id, UpdateEmployeeStatusDto dto)
    {
        var response = await _client.From<EmployeeModel>().Get();
        var employee = response.Models.Find(e => e.Id.Equals(id));

        if (employee is null)
            throw new ArgumentException($"Employee with id {id} not found");

        employee.Status = dto.Status;

        await employee.Update<EmployeeModel>();

        response.ResponseMessage.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _client.From<EmployeeModel>().Get();
        var employee = response.Models.Find(e => e.Id.Equals(id));
        
        if (employee is null)
            throw new ArgumentException($"Employee with id {id} not found");
        
        await employee.Delete<EmployeeModel>();
    }
}