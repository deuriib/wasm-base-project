using BaseProject.Adapters.Facades;
using BaseProject.Adapters.Reducers;
using BaseProject.Domain.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using BaseProject.App;
using Fluxor.Persist.Storage;
using Fluxor.Persist.Middleware;
using Blazored.LocalStorage;
using BaseProject.Infrastructure.Data.Services;
using BaseProject.Infrastructure.Providers;
using BaseProject.Infrastructure.Store;
using BaseProject.Infrastructure.Store.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var env = builder.HostEnvironment;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => 
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });

builder.Services.AddScoped<AuthenticationStateProvider, SupabaseAuthStateProvider>();
builder.Services.AddAuthorizationCore(config =>
{
    config.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

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

// Facades
builder.Services.AddScoped<AuthFacade>();
builder.Services.AddScoped<CounterFacade>();
builder.Services.AddScoped<EmployeeFacade>();
builder.Services.AddScoped<ThemeFacade>();

// Services
builder.Services.AddScoped<IEmployeeService, SupabaseEmployeeService>();
builder.Services.AddScoped<IAuthenticationService, SupabaseAuthenticationService>();
builder.Services.AddScoped<IWeatherService,WeatherService>();

builder.Services.AddBlazoredLocalStorage(config 
    => config.JsonSerializerOptions.WriteIndented = false);
builder.Services.AddScoped<IStringStateStorage, LocalStateStorage>();
builder.Services.AddScoped<IStoreHandler, JsonStoreHandler>();

builder.Services.AddFluxor(fluxorOptions =>
{
    fluxorOptions.ScanAssemblies(typeof(AppState).Assembly, 
        additionalAssembliesToScan: new[]
    {
        typeof(EmployeeReducers).Assembly
    });

    if (env.IsDevelopment())
        fluxorOptions.UseReduxDevTools();

    fluxorOptions.UseRouting();
    fluxorOptions.UsePersist(config 
        => config.UseInclusionApproach());
});

// Supabase config
var url = builder.Configuration["Supabase:Url"] ?? "";
var key = builder.Configuration["Supabase:Key"];
builder.Services.AddScoped(provider => new Client(url, key, new SupabaseOptions
{
    AutoRefreshToken = true,
    AutoConnectRealtime = true,
    PersistSession = true,
    SessionHandler = new SupabaseSessionHandler(
        provider.GetRequiredService<ILocalStorageService>(),
        provider.GetRequiredService<ILogger<SupabaseSessionHandler>>())
}));

await builder.Build().RunAsync();