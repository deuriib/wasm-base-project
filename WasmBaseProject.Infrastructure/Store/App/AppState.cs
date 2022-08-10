using Fluxor.Persist.Storage;

namespace WasmBaseProject.Infrastructure.Store.App
{
    [SkipPersistState]
    public record AppState(string AppName, string AppVersion);
}
