using System.Net.Http.Json;
using BaseProject.Domain.Models;
using BaseProject.Domain.Services;
using BaseProject.Infrastructure.Providers;
using Microsoft.Extensions.Logging;

namespace BaseProject.Infrastructure.Services;

public sealed class SupabaseAuthenticationService : IAuthenticationService
{
    private readonly ILogger<SupabaseAuthenticationService> _logger;
    private readonly HttpClient _client;
    private readonly ISessionStorageService _sessionStorageService;

    public SupabaseAuthenticationService(
        IHttpClientFactory httpClientFactory,
        ILogger<SupabaseAuthenticationService> logger,
        ISessionStorageService sessionStorageService)
    {
        _client = httpClientFactory
            .CreateClient("Supabase");
        
        _logger = logger;
        _sessionStorageService = sessionStorageService;
    }

    public async ValueTask<Session?> SignInWithEmailAndPasswordAsync(string email, string password,
        CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("Signing in with email and password");

        var response = await _client
            .PostAsJsonAsync("auth/v1/token?grant_type=password",
                new
                {
                    email,
                    password
                },
                cancellationToken: cancellationToken);

        response.EnsureSuccessStatusCode();

        var session = await response
            .Content
            .ReadFromJsonAsync<Session>(cancellationToken: cancellationToken);

        await _sessionStorageService
            .SetSessionAsync(session, cancellationToken);

        return session;
    }

    public async Task SignOutAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("Signing out");

        await SetAuthorizationHeaderAsync(cancellationToken);

        await _client
            .PostAsync("auth/v1/logout", null, cancellationToken);
        
        await _sessionStorageService.RemoveSessionAsync(cancellationToken);
    }

    public async Task SignInWithPhoneAsync(
        string phoneNumber,
        CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("Signing in with phone and password");

        var response = await _client
            .PostAsJsonAsync("auth/v1/otp",
                new
                {
                    phone = phoneNumber,
                },
                cancellationToken: cancellationToken);
        
        response.EnsureSuccessStatusCode();
    }

    public async ValueTask<Session?> VerifyPhoneAsync(
        string phoneNumber,
        string code,
        CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("Verifying phone");
        var response = await _client
            .PostAsJsonAsync("auth/v1/verify", new
            {
                type = "sms",
                phone = phoneNumber,
                token = code
            }, cancellationToken: cancellationToken);

        response.EnsureSuccessStatusCode();

        var session = await response
            .Content
            .ReadFromJsonAsync<Session>(cancellationToken: cancellationToken);

        await _sessionStorageService.SetSessionAsync(session, cancellationToken);
        
        return session;
    }

    public async ValueTask<Session?> SignUpAsync(
        string email,
        string password,
        CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("Signing up");
        var response = await _client
            .PostAsJsonAsync("auth/v1/signup", new
            {
                email,
                password
            }, cancellationToken: cancellationToken);

        response.EnsureSuccessStatusCode();

        var session = await response
            .Content
            .ReadFromJsonAsync<Session>(cancellationToken: cancellationToken);

        await _sessionStorageService.SetSessionAsync(session, cancellationToken);

        return session;
    }

    public async Task SendPasswordResetEmailAsync(
        string email, 
        CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("Sending password reset email");
        
        var response = await _client
            .PostAsJsonAsync("auth/v1/recover", new
            {
                email
            }, cancellationToken: cancellationToken);

        response.EnsureSuccessStatusCode();
    }
    
    private async Task SetAuthorizationHeaderAsync(CancellationToken cancellationToken = default)
    {
        _client.DefaultRequestHeaders.Authorization =
            new((await _sessionStorageService
                    .GetSessionAsync(cancellationToken))?.TokenType!,
                (await _sessionStorageService
                    .GetSessionAsync(cancellationToken))?.AccessToken);
    }
}