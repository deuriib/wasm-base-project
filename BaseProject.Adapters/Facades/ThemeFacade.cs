using BaseProject.Infrastructure.Store.Theme;
using Fluxor;

namespace BaseProject.Adapters.Facades;

public sealed class ThemeFacade(IDispatcher dispatcher) : IFacade
{
    public void ToggleTheme()
    {
        dispatcher.Dispatch(new ToggleThemeAction());
    }
}