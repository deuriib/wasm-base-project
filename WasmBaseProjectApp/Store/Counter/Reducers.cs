using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;

namespace WasmBaseProjectApp.Store.Counter
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

