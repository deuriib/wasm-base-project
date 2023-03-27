using Fluxor;
using Fluxor.Persist.Storage;

namespace BaseProject.Infrastructure.Store.Theme;

[PersistState]
[FeatureState]
public class ThemeState
{
    public ThemeState(bool isDarkMode)
    {
        IsDarkMode = isDarkMode;
    }
    
    private ThemeState()
    {
        IsDarkMode = false;
    }

    public bool IsDarkMode { get; }
}