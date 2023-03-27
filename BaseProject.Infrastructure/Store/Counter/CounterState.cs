using Fluxor;
using Fluxor.Persist.Storage;

namespace BaseProject.Infrastructure.Store.Counter
{
    /// <summary>
    /// The state of the counter.
    /// </summary>
    [PersistState]
    [FeatureState]
    public class CounterState
    {
        /// <summary>
        /// The state of the counter.
        /// </summary>
        public CounterState(int currentCount)
        {
            CurrentCount = currentCount;
            CurrentCount = currentCount;
        }

        public int CurrentCount { get; }

        private CounterState()
        {
            CurrentCount = 0;
        }
    }
}