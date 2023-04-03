using System.Text.Json.Serialization;
using Fluxor;
using Fluxor.Persist.Storage;

namespace BaseProject.Infrastructure.Store.App;

[PersistState]
[FeatureState]
public sealed record AppState(
    string AppName,
    string AppVersion)
{
    private AppState()
        : this(
            "BaseProject",
            "1.5.5")
    {
        IsLeftMenuOpen = true;
    }

    [property:JsonIgnore]
    public bool IsLeftMenuOpen { get; set; }
}