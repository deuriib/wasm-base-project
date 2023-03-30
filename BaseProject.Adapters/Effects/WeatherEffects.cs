using BaseProject.Domain.Services;
using BaseProject.Infrastructure.Store.Weather;
using Fluxor;

namespace BaseProject.Adapters.Effects
{
    public class WeatherEffects
    {
        private readonly IWeatherService _service;

        public WeatherEffects(IWeatherService service)
        {
            _service = service;
        }

        [EffectMethod(typeof(FetchDataAction))]
        public async Task HandleAsync(IDispatcher dispatcher)
        {
            try
            {
                var forecasts = await _service.GetWeathersAsync();
                
                if (forecasts is null)
                {
                    dispatcher.Dispatch(new FetchDataFailAction("No data"));
                    return;
                }
                
                dispatcher.Dispatch(new FetchDataSuccessAction(forecasts));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new FetchDataFailAction(ex.Message));
            }
        }
    }
}