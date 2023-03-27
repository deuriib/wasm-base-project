using BaseProject.Infrastructure.Store.Counter;
using Fluxor;

namespace BaseProject.Adapters.Store.Reducers
{
    public static class CounterReducers
    {
        [ReducerMethod]
        public static CounterState Reduce(CounterState state, IncrementCounterAction action)
            => new CounterState(currentCount: state.CurrentCount + action.IncrementBy);

        [ReducerMethod]
        public static CounterState Reduce(CounterState state, ResetCounterAction action)
            => new CounterState(currentCount: 0);
    }
}