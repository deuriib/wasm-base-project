using BaseProject.Infrastructure.Store.Counter;
using Fluxor;

namespace BaseProject.Adapters.Reducers;

public static class CounterReducers
{
    [ReducerMethod]
    public static CounterState Reduce(CounterState state, IncrementCounterAction action)
        => state with { CurrentCount = state.CurrentCount + action.IncrementBy };

    [ReducerMethod]
    public static CounterState Reduce(CounterState state, ResetCounterAction action)
        => state with { CurrentCount = 0 };
}