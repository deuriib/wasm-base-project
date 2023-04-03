using BaseProject.Adapters.Reducers;
using BaseProject.Domain.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using BaseProject.App;
using BaseProject.App.Extensions;
using Fluxor.Persist.Storage;
using Fluxor.Persist.Middleware;
using Blazored.LocalStorage;
using BaseProject.Infrastructure.Providers;
using BaseProject.Infrastructure.Services;
using BaseProject.Infrastructure.Store;
using BaseProject.Infrastructure.Store.App;
using BaseProject.Infrastructure.Validations.Auth;
using FluentValidation;
using Microsoft.AspNetCore.Components.Authorization;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var env = builder.HostEnvironment;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClientInterceptor();

builder.Services.AddHttpClient("Base", client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

builder.Services.AddHttpClient("Supabase", (sp, client) =>
{
    var url = builder.Configuration["Supabase:Url"] 
              ?? throw new NullReferenceException("Supabase url is null");
    var key = builder.Configuration["Supabase:Key"];
    
    client.BaseAddress = new Uri(url);
    client.DefaultRequestHeaders.Add("apikey", key);
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");

    client.EnableIntercept(sp);
});

// Authentication
builder.Services.AddScoped<AuthenticationStateProvider, SupabaseAuthStateProvider>();
builder.Services.AddAuthorizationCore();

// Validators
builder.Services.AddValidatorsFromAssemblyContaining<RegisterViewModelValidator>();

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopEnd;
    config.SnackbarConfiguration.PreventDuplicates = true;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = false;
    config.SnackbarConfiguration.VisibleStateDuration = 3000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

// Services
builder.Services.RegisterServices();

builder.Services.AddBlazoredLocalStorage(config 
    => config.JsonSerializerOptions.WriteIndented = false);
builder.Services.AddScoped<IStringStateStorage, LocalStateStorage>();
builder.Services.AddScoped<IStoreHandler, JsonStoreHandler>();

// Facades
builder.Services.RegisterFacades();

builder.Services.AddFluxor(fluxorOptions =>
{
    fluxorOptions.ScanAssemblies(typeof(AppState).Assembly, 
        additionalAssembliesToScan: new[]
    {
        typeof(EmployeeReducers).Assembly
    });

    if (env.IsDevelopment())
        fluxorOptions.UseReduxDevTools(options =>
        {
            options.Name = "BaseProject";
            options.EnableStackTrace();
        });

    fluxorOptions.UseRouting();
    fluxorOptions.UsePersist(config 
        => config.UseInclusionApproach());
});

await builder.Build().RunAsync();