using Fluxor.Persist.Storage;

namespace MudCounter.Store.App
{
    [SkipPersistState]
    public record AppState(string appName, string appVersion);
}
