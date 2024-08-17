using Fluxor;
using Fluxor.Persist.Storage;

namespace BaseProject.Infrastructure.Store.Counter;

/// <summary>
/// The state of the counter.
/// </summary>
[PersistState]
[FeatureState]
public sealed record CounterState(int CurrentCount)
{
    public CounterState() : this(0)
    {
    }
}
