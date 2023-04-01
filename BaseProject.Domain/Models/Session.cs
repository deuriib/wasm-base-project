using System.Text.Json.Serialization;
using BaseProject.Domain.Converters;

namespace BaseProject.Domain.Models;

public sealed record Session(
    [property: JsonPropertyName("access_token")] string? AccessToken, 
    [property: JsonPropertyName("token_type")]string? TokenType,
    [property: JsonPropertyName("refresh_token")]string? RefreshToken,
    [property: JsonPropertyName("expires_in")]int ExpiresIn,
    [property: JsonPropertyName("user"), JsonConverter(typeof(UserJsonConverter))] User User);