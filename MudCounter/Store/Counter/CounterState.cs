using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using Fluxor.Persist.Storage;

namespace MudCounter.Store.Counter
{
    /// <summary>
    /// The state of the counter.
    /// </summary>
    [PersistState]
    public record CounterState(int CurrentCount);
}

