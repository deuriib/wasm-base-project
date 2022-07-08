using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MudCounter;
using Fluxor;
using Fluxor.Persist.Storage;
using Fluxor.Persist.Middleware;
using MudCounter.Store;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using MudCounter.Services;
using MudBlazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var env = builder.HostEnvironment;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

    config.SnackbarConfiguration.PreventDuplicates = true;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = false;
    config.SnackbarConfiguration.VisibleStateDuration = 5000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

builder.Services.AddScoped<WeatherService>();

builder.Services.AddBlazoredLocalStorage(config => config.JsonSerializerOptions.WriteIndented = false);
builder.Services.AddScoped<IStringStateStorage, LocalStateStorage>();
builder.Services.AddScoped<IStoreHandler, JsonStoreHandler>();

builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(typeof(App).Assembly);

    if (env.IsDevelopment())
        options.UseReduxDevTools();
    
    options.UseRouting();
    options.UsePersist(options => options.UseInclusionApproach());
});

await builder.Build().RunAsync();
