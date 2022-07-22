using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WasmBaseProjectApp.Services;

public class EmployeeService
{
    private readonly HttpClient _httpClient;

    public EmployeeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<EmployeeListDto[]?> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<EmployeeListDto[]>("/rest/v1/employees?select=*");
    }

    public async Task<EditEmployeeDto?> GetOneAsync(int id)
    {
        var employees = await _httpClient.GetFromJsonAsync<EditEmployeeDto[]>($"/rest/v1/employees?id=eq.{id}&select=*");
        return employees?[0];
    }

    public async Task AddOneAsync(CreateEmployeeDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("/rest/v1/employees?id=eq.{id}", dto);
        response.EnsureSuccessStatusCode();
    }
     
    public async Task UpdateAsync(int id, EditEmployeeDto dto)
    {
        var content = new StringContent(JsonSerializer.Serialize(dto));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        
        var response = await _httpClient.PatchAsync($"/rest/v1/employees?id=eq.{id}", content);
        
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateStatusAsync(int id, UpdateEmployeeStatusDto dto)
    {

        var content = new StringContent(JsonSerializer.Serialize(dto));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var response = await _httpClient.PatchAsync($"/rest/v1/employees?id=eq.{id}", content);

        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"/rest/v1/employees?id=eq.{id}");
        response.EnsureSuccessStatusCode();
    }
}

public record EditEmployeeDto
{
    [JsonPropertyName("name")] public string? FirstName { get; set; }

    [JsonPropertyName("last_name")] public string? LastName { get; set; }

    [JsonPropertyName("address")] public string? Address { get; set; }

    [JsonPropertyName("note")] public string? Note { get; set; }

    [JsonPropertyName("birth_date")] public DateTime? Birthdate { get; set; }
}

public record UpdateEmployeeStatusDto
{
    [JsonPropertyName("status")]public bool Status { get; set; }
}

public record EmployeeListDto
{
    public int Id { get; set; }

    [JsonPropertyName("name")]public string? FirstName { get; set; }

    [JsonPropertyName("last_name")] public string? LastName { get; set; }

    [JsonPropertyName("status")] public bool Status { get; set; }

    [JsonPropertyName("birth_date")]
    public DateTime Birthdate { get; set; }
}

public record CreateEmployeeDto
{
    [JsonPropertyName("name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? Note { get; set; }

    [JsonPropertyName("birth_date")]
    public DateTime? Birthdate { get; set; }
};