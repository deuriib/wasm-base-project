using Fluxor.Persist.Storage;
using MudBlazor;
using System.Text.Json.Serialization;

namespace MudCounter.Store.Theme
{
    [PersistState]
    public record ThemeState(bool isDarkMode);
}
