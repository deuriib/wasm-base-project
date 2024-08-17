using BaseProject.Infrastructure.Store.Counter;
using Fluxor;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace BaseProject.Adapters.Effects
{
    public sealed class CounterEffects(ProtectedBrowserStorage localStorage)
    {

        [EffectMethod(typeof(ResetCounterAction))]
        public async Task HandleAsync(IDispatcher dispatcher)
        {
            await localStorage.DeleteAsync("counter");
        }
    }
}
