using Fluxor;
using MudCounter.Services;

namespace MudCounter.Store.Weather
{
    public class WeatherFeature : Feature<WeatherState>
    {
        public override string GetName() => "Weather";

        protected override WeatherState GetInitialState()
            => new WeatherState(isLoading: false, forecasts: Array.Empty<WeatherForecast>(), error: string.Empty);
    }
}
