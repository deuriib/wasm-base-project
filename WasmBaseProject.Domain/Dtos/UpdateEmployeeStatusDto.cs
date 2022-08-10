using System.Text.Json.Serialization;
using WasmBaseProject.Domain.Enums;

namespace WasmBaseProject.Domain.Dtos;

public record UpdateEmployeeStatusDto
{
    [JsonPropertyName("status")] public EmployeeStatus? Status { get; set; }
}