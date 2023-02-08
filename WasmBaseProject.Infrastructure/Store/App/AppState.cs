using Fluxor.Persist.Storage;

namespace WasmBaseProject.Infrastructure.Store.App
{
    [PersistState]
    public record AppState(string AppName, string AppVersion);
}
