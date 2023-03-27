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
    private readonly IDispatcher _dispatcher;
    private readonly IState<AuthState> _authState;
    private const string SessionKey = "SUPABASE_SESSION";

    public SupabaseSessionHandler(
        ILocalStorageService localStorage, 
        ILogger<SupabaseSessionHandler> logger, 
        IDispatcher dispatcher,
        IState<AuthState> authState)
    {
        _localStorage = localStorage;
        _logger = logger;
        _dispatcher = dispatcher;
        _authState = authState;
    }

    public async Task<bool> SessionPersistor<TSession>(TSession session) where TSession : Session
    {
        await _localStorage.SetItemAsync(SessionKey, session);
        _dispatcher.Dispatch(new SaveSessionAction(session));
        return true;
    }

    public async Task<TSession?> SessionRetriever<TSession>() where TSession : Session
    {
        var session = await _localStorage.GetItemAsync<Session>(SessionKey);
        var session2 = _authState.Value.Session;

        return session?.ExpiresAt() <= DateTime.Now
            ? null!
            : (TSession?)(await _localStorage.GetItemAsync<Session>(SessionKey));
    }

    public async Task<bool> SessionDestroyer()
    {
        await _localStorage.RemoveItemAsync(SessionKey);
        _dispatcher.Dispatch(new RemoveSessionAction());
        return true;
    }
}