using AutoMapper;
using Postgrest;
using WasmBaseProject.Domain.Dtos;
using WasmBaseProject.Domain.Models;
using WasmBaseProject.Domain.Services;
using WasmBaseProject.Infrastructure.Data.Models;

namespace WasmBaseProject.Infrastructure.Data.Services;

public class SupabaseEmployeeRepository : IEmployeeRepository
{
    private readonly IMapper _mapper;
    private readonly Supabase.Client _client;

    public SupabaseEmployeeRepository(IMapper mapper)
    {
        _mapper = mapper;
        _client = Supabase.Client.Instance;
    }

    public async Task<Employee[]?> GetAllAsync()
    {
        var response = await _client.From<EmployeeModel>().Order("id", Constants.Ordering.Ascending).Get();
        response.ResponseMessage.EnsureSuccessStatusCode();

        return _mapper.Map<Employee[]>(response.Models.ToArray());
    }

    public async Task<Employee?> GetOneAsync(int id)
    {
        var response = await _client.From<EmployeeModel>().Get();
        response.ResponseMessage.EnsureSuccessStatusCode();
        
        var model = response.Models.Find(e => e.Id.Equals(id));
        return _mapper.Map<Employee>(model);
    }

    public async Task<Employee?> CreateAsync(CreateEmployeeDto dto)
    {
        var response = await _client.From<EmployeeModel>().Insert(
            new EmployeeModel
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Address = dto.Address,
                Email = dto.Email,
                Note = dto.Note,
                Birthdate = dto.Birthdate
            });

        response.ResponseMessage.EnsureSuccessStatusCode();

        var employee = response.Models.FindLast(e => e.Email!.Equals(dto.Email));
        return _mapper.Map<Employee>(employee);
    }

    public async Task<Employee?> UpdateAsync(int id, EditEmployeeDto dto)
    {
        var response = await _client.From<EmployeeModel>().Get();
        response.ResponseMessage.EnsureSuccessStatusCode();
        
        var employee = response.Models.Find(e => e.Id.Equals(id));

        if (employee is null)
            throw new ArgumentException($"Employee with id {id} not found");

        employee.FirstName = dto.FirstName;
        employee.LastName = dto.LastName;
        employee.Address = dto.Address;
        employee.Email = dto.Email;
        employee.Note = dto.Note;
        employee.Birthdate = dto.Birthdate;

        var updatedResponse = await employee.Update<EmployeeModel>();

        updatedResponse.ResponseMessage.EnsureSuccessStatusCode();
        
        var updatedEmployee = updatedResponse.Models.FindLast(e => e.Id.Equals(id));
        return _mapper.Map<Employee>(updatedEmployee);
    }

    public async Task<Employee?> UpdateStatusAsync(int id, UpdateEmployeeStatusDto dto)
    {
        var response = await _client.From<EmployeeModel>().Get();
        var employee = response.Models.Find(e => e.Id.Equals(id));

        if (employee is null)
            throw new ArgumentException($"Employee with id {id} not found");

        employee.Status = dto.Status;

        var updatedResponse = await employee.Update<EmployeeModel>();

        updatedResponse.ResponseMessage.EnsureSuccessStatusCode();
        
        var updatedEmployee = updatedResponse.Models.FindLast(e => e.Id!.Equals(id));
        return _mapper.Map<Employee>(updatedEmployee);
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _client.From<EmployeeModel>().Get();
        response.ResponseMessage.EnsureSuccessStatusCode();
        
        var employee = response.Models.Find(e => e.Id.Equals(id));

        if (employee is null)
            throw new ArgumentException($"Employee with id {id} not found");

        await employee.Delete<EmployeeModel>();
    }
}