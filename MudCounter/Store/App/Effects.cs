using Blazored.LocalStorage;
using Fluxor;

namespace MudCounter.Store.App
{
    public class Effects
    {
        private readonly ILocalStorageService _localStorage;

        public Effects(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        [EffectMethod]
        public async Task HandleAsync(ClearStorageAction action, IDispatcher dispatcher)
        {
            await _localStorage.ClearAsync();
        }
    }
}
