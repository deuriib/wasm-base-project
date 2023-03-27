using Fluxor;
using Fluxor.Persist.Storage;

namespace BaseProject.Infrastructure.Store.App;

[PersistState]
[FeatureState]
public class AppState
{
    public AppState(string name, string version)
    {
        AppName = name;
        AppVersion = version;
    }

    public string AppName { get;  }
    public string AppVersion { get; }

    private AppState()
    {
        AppName = "BaseProject";
        AppVersion = "1.5.4";
    }
}