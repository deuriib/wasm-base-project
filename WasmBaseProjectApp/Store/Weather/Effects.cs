using Fluxor;
using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Store.Weather
{
    public class Effects
    {
        private readonly WeatherService _service;

        public Effects(WeatherService service)
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
