using BaseProject.Web.Components;
using BaseProject.Infrastructure.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using BaseProject.Web.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();


// Authentication & Authorization
builder.Services.AddAuthorization();
builder.Services.AddAuthentication()
.AddCookie(config => config.LoginPath = "/authentication/login");
builder.Services.AddCascadingAuthenticationState();

// Services
builder.Services.AddScoped<AuthenticationStateProvider, SupabaseAuthStateProvider>();
builder.Services.RegisterMudBlazor();
builder.Services.RegisterSupabase(builder.Configuration);

builder.Services.RegisterFluentValidations();

builder.Services.RegisterServices();
builder.Services.RegisterFacades();

builder.Services.RegisterFluxor(builder.Environment.IsDevelopment());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthorization();
app.UseAuthentication();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    // .RequireAuthorization()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BaseProject.Web.Client._Imports).Assembly);

app.Run();
