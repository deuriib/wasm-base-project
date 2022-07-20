using System.Net.Http.Json;
using Bogus;
using System.Linq;
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

    public async Task<EmployeeDto?> GetOneAsync(int id)
    {
        var employees = await _httpClient.GetFromJsonAsync<EmployeeDto[]>($"/rest/v1/employees?id=eq.{id}&select=*");
        return employees?[0];
    }

    public async Task AddOneAsync(CreateEmployeeDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("/rest/v1/employees?id=eq.{id}", dto);
        response.EnsureSuccessStatusCode();
    }
     
    public async Task UpdateAsync(int id, EmployeeListDto request)
    {
        await _httpClient.PostAsJsonAsync($"api/employees/{id}", request);
    }

    public async Task UpdateStatusAsync(int id, bool newStatus)
    {

        var content = new StringContent(JsonSerializer.Serialize(new { status = newStatus }));
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

public record EmployeeDto
{
    public int Id { get; set; }

    [JsonPropertyName("name")] public string? FirstName { get; set; }

    [JsonPropertyName("last_name")] public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? Note { get; set; }

    [JsonPropertyName("birth_date")]
    public DateTime Birthdate { get; set; }
}

public record EmployeeListDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    [JsonPropertyName("last_name")] public string? LastName { get; set; }

    public bool Status { get; set; }

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