using Fluxor.Persist.Storage;

namespace WasmBaseProject.Infrastructure.Store.Theme
{
    [PersistState]
    public record ThemeState(bool isDarkMode);
}
