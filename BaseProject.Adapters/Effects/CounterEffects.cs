using BaseProject.Infrastructure.Store.Counter;
using Blazored.LocalStorage;
using Fluxor;

namespace BaseProject.Adapters.Effects
{
    public class CounterEffects
    {
        private readonly ILocalStorageService _localStorage;

        public CounterEffects(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        [EffectMethod(typeof(ResetCounterAction))]
        public async Task HandleAsync(IDispatcher dispatcher)
        {
            await _localStorage.RemoveItemAsync("counter");
        }
    }
}