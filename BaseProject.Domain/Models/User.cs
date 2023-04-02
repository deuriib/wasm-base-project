using System.Text.Json.Serialization;

namespace BaseProject.Domain.Models;

public sealed record User(
    [property:JsonPropertyName("id")] Guid Id,
    [property:JsonPropertyName("role")] string Role,
    [property:JsonPropertyName("email")] string Email);