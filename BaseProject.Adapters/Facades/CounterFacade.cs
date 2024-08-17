using BaseProject.Infrastructure.Store.Counter;
using Fluxor;

namespace BaseProject.Adapters.Facades;

public sealed class CounterFacade(IDispatcher dispatcher) : IFacade
{
    public void IncrementCounter(int incrementBy)
    {
        dispatcher.Dispatch(new IncrementCounterAction(incrementBy));
    }

    public void ResetCounter()
    {
        dispatcher.Dispatch(new ResetCounterAction());
    }
}