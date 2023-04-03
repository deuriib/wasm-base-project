using BaseProject.Infrastructure.Store.App;
using Fluxor;

namespace BaseProject.Adapters.Facades;

public class AppFacade : IFacade
{
    private readonly IDispatcher _dispatcher;

    public AppFacade(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }
    
    public void ToggleLeftMenu()
    {
        _dispatcher.Dispatch(new ToggleLeftMenuAction());
    }
}