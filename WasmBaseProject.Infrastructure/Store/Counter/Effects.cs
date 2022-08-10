using Blazored.LocalStorage;
using Fluxor;

namespace WasmBaseProject.Infrastructure.Store.Counter
{
    public class Effects
    {
        private readonly ILocalStorageService _localStorage;

        public Effects(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        [EffectMethod]
        public async Task HandleAsync(ResetCounterAction action, IDispatcher dispatcher)
        {
            await _localStorage.RemoveItemAsync("counter");
        }
    }
}
