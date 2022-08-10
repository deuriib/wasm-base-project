using Fluxor.Persist.Storage;

namespace WasmBaseProject.Infrastructure.Store.Counter
{
    /// <summary>
    /// The state of the counter.
    /// </summary>
    [PersistState]
    public record CounterState(int CurrentCount);
}

