using Fluxor.Persist.Storage;

namespace WasmBaseProjectApp.Store.App
{
    [SkipPersistState]
    public record AppState(string appName, string appVersion);
}
