using BaseProject.Domain.Models;
using Fluxor;
using Fluxor.Persist.Storage;

namespace BaseProject.Infrastructure.Store.Weather
{
    [SkipPersistState]
    [FeatureState]
    public class WeatherState
    {
        public bool IsLoading { get; }
        public WeatherForecast[] Forecasts { get; }
        public string ErrorMessage { get; }

        private WeatherState()
        {
            IsLoading = false;
            Forecasts = Array.Empty<WeatherForecast>();
            ErrorMessage = string.Empty;
        }
        
        public WeatherState(bool isLoading, WeatherForecast[] forecasts, string errorMessage)
        {
            IsLoading = isLoading;
            Forecasts = forecasts;
            ErrorMessage = errorMessage;
        }
    }
}