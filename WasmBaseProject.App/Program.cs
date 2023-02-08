using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using WasmBaseProject.App;
using Fluxor;
using Fluxor.Persist.Storage;
using Fluxor.Persist.Middleware;
using Blazored.LocalStorage;
using MediatR;
using MudBlazor;
using WasmBaseProject.Adapters.Mappers;
using WasmBaseProject.Adapters.Services;
using WasmBaseProject.Domain.Services;
using WasmBaseProject.Infrastructure;
using WasmBaseProject.Infrastructure.Data.Services;
using WasmBaseProject.Infrastructure.Store;
using WasmBaseProject.Infrastructure.Store.Weather;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var env = builder.HostEnvironment;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddAutoMapper(
    typeof(EmployeeProfile).Assembly);

builder.Services.AddMediatR(typeof(InfrastructureInitializer).Assembly);

await InfrastructureInitializer.InitializeAsync(builder.Configuration);

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
    config.SnackbarConfiguration.PreventDuplicates = true;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = false;
    config.SnackbarConfiguration.VisibleStateDuration = 3000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

builder.Services.AddSingleton<IEmployeeRepository, SupabaseEmployeeRepository>();
builder.Services.AddSingleton<EmployeeService>();

builder.Services.AddScoped<WeatherService>();

builder.Services.AddBlazoredLocalStorage(config => config.JsonSerializerOptions.WriteIndented = false);
builder.Services.AddScoped<IStringStateStorage, LocalStateStorage>();
builder.Services.AddScoped<IStoreHandler, JsonStoreHandler>();

builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(typeof(InfrastructureInitializer).Assembly, additionalAssembliesToScan: new[]
    {
        typeof(WeatherReducers).Assembly
    });

    if (env.IsDevelopment())
        options.UseReduxDevTools();

    options.UseRouting();
    options.UsePersist(config => config.UseInclusionApproach());
});

await builder.Build().RunAsync();