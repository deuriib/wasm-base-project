using WasmBaseProjectApp.Services;

namespace WasmBaseProjectApp.Store.Weather
{
    public class FetchDataAction
    {
    }

    public class FetchDataSuccessAction
    {
        public WeatherForecast[] Forecasts { get; }

        public FetchDataSuccessAction(WeatherForecast[] forecasts)
        {
            Forecasts = forecasts;
        }
    }

    public class FetchDataFailAction
    {
        public string ErrorMessage { get; }

        public FetchDataFailAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
