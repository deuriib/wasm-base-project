using BaseProject.Infrastructure.Store.App;
using Blazored.LocalStorage;
using Fluxor;

namespace BaseProject.Adapters.Store.Effects
{
    public class AppEffects
    {
        private readonly ILocalStorageService _localStorage;

        public AppEffects(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        [EffectMethod(typeof(ClearStorageAction))]
        public async Task HandleAsync(IDispatcher dispatcher)
        {
            await _localStorage.ClearAsync();
        }
    }
}