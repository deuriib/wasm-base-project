namespace BaseProject.Infrastructure.Store.Counter
{
    public class IncrementCounterAction
    {
        public IncrementCounterAction(int incrementBy)
        {
            IncrementBy = incrementBy;
        }
        public int IncrementBy { get; }
    }
}

