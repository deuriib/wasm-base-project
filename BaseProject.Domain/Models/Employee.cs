using System.Text.Json.Serialization;
using Ardalis.SmartEnum.SystemTextJson;
using BaseProject.Domain.Enums;

namespace BaseProject.Domain.Models;

public sealed record Employee(
    [property: JsonPropertyName("id")] long Id,
    [property: JsonPropertyName("name")] string FirstName,
    [property: JsonPropertyName("last_name")]
    string LastName,
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("birth_date")]
    DateTime Birthdate,
    [property: JsonConverter(typeof(SmartEnumValueConverter<EmployeeStatus, bool>))]
    EmployeeStatus Status)
{
    [JsonPropertyName("address")] public string? Address { get; init; }

    [JsonPropertyName("note")] public string? Note { get; init; }
}