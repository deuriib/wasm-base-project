using BaseProject.Infrastructure.Store.Auth;
using Blazored.LocalStorage;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Supabase.Gotrue;
using Supabase.Interfaces;

namespace BaseProject.Infrastructure.Providers;

public class SupabaseSessionHandler : ISupabaseSessionHandler
{
    private readonly ILocalStorageService _localStorage;
    private readonly ILogger<SupabaseSessionHandler> _logger;
    private const string SessionKey = "SUPABASE_SESSION";

    public SupabaseSessionHandler(
        ILocalStorageService localStorage,
        ILogger<SupabaseSessionHandler> logger
    )
    {
        _localStorage = localStorage;
        _logger = logger;
    }

    public async Task<bool> SessionPersistor<TSession>(TSession session) where TSession : Session
    {
        await _localStorage.SetItemAsync(SessionKey, session);
        return true;
    }

    public async Task<TSession?> SessionRetriever<TSession>() where TSession : Session
    {
        var session = await _localStorage.GetItemAsync<Session>(SessionKey);

        return session?.ExpiresAt() <= DateTime.Now
            ? null!
            : (TSession?)(await _localStorage.GetItemAsync<Session>(SessionKey));
    }

    public async Task<bool> SessionDestroyer()
    {
        await _localStorage.RemoveItemAsync(SessionKey);
        return true;
    }
}