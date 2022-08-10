using Fluxor;
using WasmBaseProject.Adapters.Services;
using WasmBaseProject.Infrastructure.Store.Weather;

namespace WasmBaseProject.Adapters.Store.Effects
{
    public class WeatherEffects
    {
        private readonly WeatherService _service;

        public WeatherEffects(WeatherService service)
        {
            _service = service;
        }

        [EffectMethod]
        public async Task HandleAsync(FetchDataAction action, IDispatcher dispatcher)
        {
            try
            {
                var forecasts = await _service.GetWeathersAsync();
                dispatcher.Dispatch(new FetchDataSuccessAction(forecasts));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new FetchDataFailAction(ex.Message));
            }
        }
    }
}
