using System.Net.Http.Json;
using Bogus;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WasmBaseProjectApp.Services;

public class EmployeeService
{
    private readonly HttpClient _httpClient;

    public EmployeeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Employee[]?> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<Employee[]>("/rest/v1/employees?select=*");
    }

    public async Task AddOneAsync(Employee request)
    {
        await _httpClient.PostAsJsonAsync("api/employees", request);
    }

    public async Task UpdateAsync(int id, Employee request)
    {
        await _httpClient.PostAsJsonAsync($"api/employees/{id}", request);
    }

    public async Task UpdateStatusAsync(int id, bool newStatus)
    {
        var content = new StringContent(JsonConvert.SerializeObject(new { status = newStatus }));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await _httpClient.PatchAsync($"/rest/v1/employees?id=eq.{id}", content
        );

        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        await _httpClient.DeleteAsync($"/rest/v1/employees?id=eq.{id}");
    }
}

public class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }

    [JsonPropertyName("last_name")] public string? LastName { get; set; }
    public string? Address { get; set; }
    public bool Status { get; set; }
    public string? Note { get; set; }

    [JsonPropertyName("year_of_birth")] public int YearOfBirth { get; set; }

    [JsonPropertyName("day_of_birth")] public int DayOfBirth { get; set; }

    [JsonProperty("month_of_birth")] public int MonthOfBirth { get; set; }

    [JsonProperty("created_at")] public DateTime CreateDate { get; set; }
}