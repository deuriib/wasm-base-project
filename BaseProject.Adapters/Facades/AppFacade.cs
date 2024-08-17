using BaseProject.Infrastructure.Store.App;
using Fluxor;

namespace BaseProject.Adapters.Facades;

public sealed class AppFacade(IDispatcher dispatcher) : IFacade
{
    public void ToggleLeftMenu()
    {
        dispatcher.Dispatch(new ToggleLeftMenuAction());
    }
}