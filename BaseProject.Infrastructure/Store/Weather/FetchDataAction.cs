using BaseProject.Domain.Models;

namespace BaseProject.Infrastructure.Store.Weather;

public record FetchDataAction;

public record FetchDataSuccessAction(WeatherForecast[] Forecasts);

public record FetchDataFailAction(string ErrorMessage);