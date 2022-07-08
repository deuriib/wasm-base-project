using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MudCounter.Store.Counter
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

