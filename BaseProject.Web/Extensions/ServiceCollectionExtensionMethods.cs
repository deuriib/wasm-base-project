using System.Reflection;
using BaseProject.Adapters.Facades;
using BaseProject.Domain.Services;
using BaseProject.Infrastructure.Services;

namespace BaseProject.App.Extensions;

public static class ServiceCollectionExtensionMethods
{
    public static IServiceCollection RegisterFacades(this IServiceCollection services)
    {
        var facades = Assembly
            .GetAssembly(typeof(IFacade))!
            .GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(IFacade)) && t is
            {
                IsInterface: false,
                IsAbstract: false
            })
            .ToList();

        foreach (var facade in facades)
        {
            services.AddScoped(facade);
        }

        return services;
    }

    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IHttpInterceptorService, HttpInterceptorService>();
        services.AddScoped<IEmployeeService, SupabaseEmployeeService>();
        services.AddScoped<IAuthenticationService, SupabaseAuthenticationService>();
        services.AddScoped<ISessionStorageService, SessionStorageService>();
        services.AddScoped<IWeatherService, WeatherService>();

        return services;
    }
}