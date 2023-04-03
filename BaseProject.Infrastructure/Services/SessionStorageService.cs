using BaseProject.Domain.Models;
using BaseProject.Domain.Services;
using Blazored.LocalStorage;

namespace BaseProject.Infrastructure.Services;

public sealed class SessionStorageService : ISessionStorageService, IService
{
    private readonly ILocalStorageService _localStorageService;
    private const string SessionKey = "SESSION_KEY";

    public SessionStorageService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public async Task SetSessionAsync(Session? session, CancellationToken cancellationToken = default)
    {
        await _localStorageService.SetItemAsync(SessionKey, session, cancellationToken);
    }

    public async Task<Session?> GetSessionAsync(CancellationToken cancellationToken = default)
    {
        return await _localStorageService.GetItemAsync<Session>(SessionKey, cancellationToken);
    }

    public async Task RemoveSessionAsync(CancellationToken cancellationToken = default)
    {
        await _localStorageService.RemoveItemAsync(SessionKey, cancellationToken);
    }
}