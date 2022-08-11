using Fluxor;
using WasmBaseProject.Domain.Models;

namespace WasmBaseProject.Infrastructure.Store.Weather
{
    public class WeatherFeature : Feature<WeatherState>
    {
        public override string GetName() => "Weather";

        protected override WeatherState GetInitialState()
            => new WeatherState(IsLoading: false, Forecasts: Array.Empty<WeatherForecast>(), Error: string.Empty);
    }
}
