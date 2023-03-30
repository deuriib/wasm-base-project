using BaseProject.Domain.Services;
using Microsoft.Extensions.Logging;
using Supabase.Gotrue;

namespace BaseProject.Infrastructure.Services;

public sealed class SupabaseAuthenticationService : IAuthenticationService
{
    private readonly Supabase.Client _supabaseClient;
    private readonly ILogger<SupabaseAuthenticationService> _logger;
    public SupabaseAuthenticationService(
        Supabase.Client supabaseClient,
        ILogger<SupabaseAuthenticationService> logger)
    {
        _supabaseClient = supabaseClient;
        _logger = logger;
    }

    public async ValueTask<Session?> SignInWithEmailAndPasswordAsync(string email, string password)
    {
        _logger.LogDebug("Signing in with email and password");
        
        return await _supabaseClient
            .Auth
            .SignIn(email, password);
    }

    public async Task SignOutAsync()
    {
        _logger.LogDebug("Signing out");
        
        await _supabaseClient
            .Auth
            .SignOut();
    }

    public async ValueTask<Session?> SignInWithPhoneAndPasswordAsync(string phoneNumber, string password)
    {
        _logger.LogDebug("Signing in with phone and password");
        
        return await _supabaseClient
            .Auth
            .SignIn(Constants.SignInType.Phone, phoneNumber, password);
    }
    
    public async ValueTask<Session?> SignUpAsync(string email, string password)
    {
        _logger.LogDebug("Signing up");
        
        return await _supabaseClient
            .Auth
            .SignUp(email, password);
    }

    public async ValueTask<Session?> SignInWithGoogleAsync()
    {
        _logger.LogDebug("Signing in with Google");
        
        var signInUrl = await _supabaseClient
            .Auth
            .SignIn(Constants.Provider.Google, scopes:"openid profile email");
        
        return await _supabaseClient
            .Auth
            .GetSessionFromUrl(new Uri(signInUrl));
    }
}