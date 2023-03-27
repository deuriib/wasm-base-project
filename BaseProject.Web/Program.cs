using BaseProject.Adapters.Services;
using BaseProject.Adapters.Store.Reducers;
using BaseProject.Domain.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using BaseProject.App;
using Fluxor.Persist.Storage;
using Fluxor.Persist.Middleware;
using Blazored.LocalStorage;
using BaseProject.Infrastructure.Data.Services;
using BaseProject.Infrastructure.Store;
using BaseProject.Infrastructure.Store.App;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var env = builder.HostEnvironment;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => 
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });

// Supabase config
var url = builder.Configuration["Supabase:Url"] ?? "";
var key = builder.Configuration["Supabase:Key"];
var options = new SupabaseOptions
{
    AutoRefreshToken = true,
    AutoConnectRealtime = true
};
builder.Services.AddSingleton(_ => new Client(url, key, options));

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
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

builder.Services.AddFluxor(fluxorOptions =>
{
    fluxorOptions.ScanAssemblies(typeof(AppState).Assembly, additionalAssembliesToScan: new[]
    {
        typeof(EmployeeReducers).Assembly
    });

    if (env.IsDevelopment())
        fluxorOptions.UseReduxDevTools();

    fluxorOptions.UseRouting();
    fluxorOptions.UsePersist(config => config.UseInclusionApproach());
});

await builder.Build().RunAsync();