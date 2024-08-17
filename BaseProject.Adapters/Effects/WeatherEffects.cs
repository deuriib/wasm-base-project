using BaseProject.Domain.Models;
using BaseProject.Domain.Services;
using BaseProject.Infrastructure.Store.Weather;
using Fluxor;

namespace BaseProject.Adapters.Effects
{
    public sealed class WeatherEffects(IWeatherService weatherService)
    {

        [EffectMethod(typeof(FetchDataAction))]
        public async Task HandleAsync(IDispatcher dispatcher)
        {
            try
            {
                var forecasts = await weatherService.GetWeathersAsync();

                dispatcher.Dispatch(new FetchDataSuccessAction(forecasts ?? Array.Empty<WeatherForecast>()));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new FetchDataFailAction(ex.Message));
            }
        }
    }
}