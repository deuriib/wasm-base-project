using Fluxor;

namespace WasmBaseProject.Infrastructure.Store.Counter
{
    public static class Reducers
    {
        [ReducerMethod]
        public static CounterState Reduce(CounterState state, IncrementCounterAction action)
            => state with { CurrentCount = state.CurrentCount + action.IncrementBy };

        [ReducerMethod]
        public static CounterState Reduce(CounterState state, ResetCounterAction action)
            => state with { CurrentCount = 0 };
    }
}

