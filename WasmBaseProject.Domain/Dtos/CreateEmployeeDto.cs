using System.Text.Json.Serialization;

namespace WasmBaseProject.Domain.Dtos;

public record CreateEmployeeDto
{
    [JsonPropertyName("name")] public string? FirstName { get; set; }

    [JsonPropertyName("last_name")] public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? Note { get; set; }

    [JsonPropertyName("birth_date")] public DateTime? Birthdate { get; set; }
};