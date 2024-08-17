using System.Security.Claims;
using BaseProject.Domain.Services;
using BaseProject.Infrastructure.Extensions;
using BaseProject.Infrastructure.Services;
using BaseProject.Infrastructure.Utils;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;

namespace BaseProject.Infrastructure.Providers;

public sealed class SupabaseAuthStateProvider(
    ILogger<SupabaseAuthStateProvider> logger,
    ISessionStorageService sessionStorageService) : AuthenticationStateProvider
{
    private readonly AuthenticationState _anonymousState = new(new ClaimsPrincipal(new ClaimsIdentity()));

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        logger.LogDebug("GetAuthenticationStateAsync");

        var session = await sessionStorageService
            .GetSessionAsync();

        logger.LogDebug("Session: {session}", session);

        var identity = session is not null
            ? new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(session.AccessToken),
                session.TokenType)
            : new ClaimsIdentity();

        if (identity.HasExpiredToken())
        {
            NotifyAuthenticationStateChanged(Task.FromResult(_anonymousState));
            return _anonymousState;
        }

        logger.LogDebug("Identity: {identity}", identity);

        var state = new AuthenticationState(new ClaimsPrincipal(identity));

        logger.LogDebug("AuthenticationState: {state}", state);

        NotifyAuthenticationStateChanged(Task.FromResult(state));

        return state;
    }
}
