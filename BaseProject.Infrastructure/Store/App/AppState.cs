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
    public AppState() : this("BaseProject", "1.6.5")
    {
    }

    [property: JsonIgnore]
    public bool IsLeftMenuOpen { get; set; } = true;
}
