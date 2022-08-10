using Fluxor;
using WasmBaseProject.Domain.Models;

namespace WasmBaseProject.Infrastructure.Store.Weather
{
    public class WeatherFeature : Feature<WeatherState>
    {
        public override string GetName() => "Weather";

        protected override WeatherState GetInitialState()
            => new WeatherState(isLoading: false, forecasts: Array.Empty<WeatherForecast>(), error: string.Empty);
    }
}
