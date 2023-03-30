using System.Security.Claims;
using BaseProject.Domain.Services;
using BaseProject.Infrastructure.Utils;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;

namespace BaseProject.Infrastructure.Providers;

public class SupabaseAuthStateProvider : AuthenticationStateProvider
{
    private readonly IAuthenticationService _authService;
    private readonly ILogger<SupabaseAuthStateProvider> _logger;
    private readonly Supabase.Client _supabaseClient;

    public SupabaseAuthStateProvider(
        ILogger<SupabaseAuthStateProvider> logger,
        IAuthenticationService authService, Supabase.Client supabaseClient)
    {
        _logger = logger;
        _authService = authService;
        _supabaseClient = supabaseClient;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        _logger.LogDebug("GetAuthenticationStateAsync");
        
        await _supabaseClient.InitializeAsync();
        
        var session = _supabaseClient.Auth.CurrentSession;

        var token = session?.AccessToken;
        
        _logger.LogDebug("Token: {token}", token);

        var identity = !string.IsNullOrEmpty(token)
            ? new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token),
                "supabase")
            : new ClaimsIdentity();
        
        _logger.LogDebug("Identity: {identity}", identity);

        var state = new AuthenticationState(new ClaimsPrincipal(identity));
        
        _logger.LogDebug("AuthenticationState: {state}", state);

        NotifyAuthenticationStateChanged(Task.FromResult(state));

        return state;
    }
}