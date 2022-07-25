using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using WasmBaseProjectApp;
using Fluxor;
using Fluxor.Persist.Storage;
using Fluxor.Persist.Middleware;
using Blazored.LocalStorage;
using MudBlazor;
using WasmBaseProjectApp.Data.Repositories;
using WasmBaseProjectApp.Services;
using WasmBaseProjectApp.Store;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var env = builder.HostEnvironment;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var initializeSupabase = async () =>
{
    var url = builder.Configuration.GetValue<string>("SupabaseConfig:Url");
    var key = builder.Configuration.GetValue<string>("SupabaseConfig:Key");

    await Supabase.Client.InitializeAsync(url, key);
};

initializeSupabase().Wait();

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

builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddSingleton<EmployeeService>();

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
    options.UsePersist(config => config.UseInclusionApproach());
});

await builder.Build().RunAsync();
