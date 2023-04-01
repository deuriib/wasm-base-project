using System.Security.Claims;
using BaseProject.Domain.Models;

namespace BaseProject.Infrastructure.Extensions;

public static class ClaimsIdentityExtensions
{
    public static bool HasExpiredToken(this ClaimsIdentity identity)
    {
        var expiryClaim = identity.FindFirst("exp");
        var expiryTime = long.TryParse(expiryClaim?.Value, out var expiry)
            ? expiry
            : 0;
        return expiryTime < DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }
}