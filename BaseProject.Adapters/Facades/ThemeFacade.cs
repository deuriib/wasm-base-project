using BaseProject.Infrastructure.Store.Theme;
using Fluxor;

namespace BaseProject.Adapters.Facades;

public class ThemeFacade
{
    private readonly IDispatcher _dispatcher;

    public ThemeFacade(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }
    
    public void ToggleTheme()
    {
        _dispatcher.Dispatch(new ToggleThemeAction());
    }
}