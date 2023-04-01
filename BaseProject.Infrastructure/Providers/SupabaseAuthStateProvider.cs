using System.Security.Claims;
using BaseProject.Infrastructure.Extensions;
using BaseProject.Infrastructure.Utils;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;

namespace BaseProject.Infrastructure.Providers;

public class SupabaseAuthStateProvider : AuthenticationStateProvider
{
    private readonly ILogger<SupabaseAuthStateProvider> _logger;
    private readonly SessionStorageProvider _sessionStorageProvider;
    private readonly AuthenticationState _anonymousState = new(new ClaimsPrincipal(new ClaimsIdentity()));

    public SupabaseAuthStateProvider(
        ILogger<SupabaseAuthStateProvider> logger,
        SessionStorageProvider sessionStorageProvider)
    {
        _logger = logger;
        _sessionStorageProvider = sessionStorageProvider;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        _logger.LogDebug("GetAuthenticationStateAsync");

        var session = await _sessionStorageProvider
            .GetSessionAsync();

        _logger.LogDebug("Session: {session}", session);

        var identity = session is not null
            ? new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(session.AccessToken),
                session.TokenType)
            : new ClaimsIdentity();

        if (identity.HasExpiredToken())
        {
            NotifyAuthenticationStateChanged(Task.FromResult(_anonymousState));
            return _anonymousState;
        }

        _logger.LogDebug("Identity: {identity}", identity);

        var state = new AuthenticationState(new ClaimsPrincipal(identity));

        _logger.LogDebug("AuthenticationState: {state}", state);

        NotifyAuthenticationStateChanged(Task.FromResult(state));

        return state;
    }
}