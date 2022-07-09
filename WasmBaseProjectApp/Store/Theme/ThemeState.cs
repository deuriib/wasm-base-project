using Fluxor.Persist.Storage;
using MudBlazor;
using System.Text.Json.Serialization;

namespace WasmBaseProjectApp.Store.Theme
{
    [PersistState]
    public record ThemeState(bool isDarkMode);
}
