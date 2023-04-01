using System.Security.Claims;
using System.Text.Json;

namespace BaseProject.Infrastructure.Utils;

public static class JwtParser
{
    public static IEnumerable<Claim> ParseClaimsFromJwt(string? jwt)
    {
        if (jwt is null)
            return Array.Empty<Claim>();

        var claims = new List<Claim>();
        var payload = jwt.Split('.')[1];

        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        if (keyValuePairs is not null)
            claims.AddRange(keyValuePairs.Select(kvp =>
                new Claim(kvp.Key, kvp.Value.ToString()!)));

        return claims;
    }

    private static byte[] ParseBase64WithoutPadding(string payload)
    {
        switch (payload.Length % 4)
        {
            case 2:
                payload += "==";
                break;
            case 3:
                payload += "=";
                break;
        }

        return Convert.FromBase64String(payload);
    }
}