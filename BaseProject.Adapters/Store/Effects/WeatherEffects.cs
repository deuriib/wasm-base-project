using BaseProject.Adapters.Services;
using BaseProject.Infrastructure.Store.Weather;
using Fluxor;

namespace BaseProject.Adapters.Store.Effects
{
    public class WeatherEffects
    {
        private readonly WeatherService _service;

        public WeatherEffects(WeatherService service)
        {
            _service = service;
        }

        [EffectMethod(typeof(FetchDataAction))]
        public async Task HandleAsync(IDispatcher dispatcher)
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