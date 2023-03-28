using BaseProject.Infrastructure.Store.Counter;
using Fluxor;

namespace BaseProject.Adapters.Facades;

public class CounterFacade
{
    private readonly IDispatcher _dispatcher;

    public CounterFacade(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }
    
    public void IncrementCounter(int incrementBy)
    {
        _dispatcher.Dispatch(new IncrementCounterAction(incrementBy));
    }
    
    public void ResetCounter()
    {
        _dispatcher.Dispatch(new ResetCounterAction());
    }
}