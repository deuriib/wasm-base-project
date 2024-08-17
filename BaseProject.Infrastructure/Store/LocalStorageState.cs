using Fluxor.Persist.Storage;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace BaseProject.Infrastructure.Store;

public sealed class LocalStateStorage(ProtectedBrowserStorage localStorage) : IStringStateStorage
{
    public async ValueTask<string> GetStateJsonAsync(string statename)
    {
        var result = await localStorage.GetAsync<string>(statename);

        return result.Value ?? string.Empty;
    }

    public async ValueTask StoreStateJsonAsync(string statename, string json)
        => await localStorage.SetAsync(statename, json);
}
