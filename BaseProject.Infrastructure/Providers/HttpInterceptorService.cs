using System.Net;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Toolbelt.Blazor;

namespace BaseProject.Infrastructure.Providers;

public class HttpInterceptorService : IDisposable
{
    private readonly IHttpClientInterceptor _interceptor;
    private readonly ILogger<HttpInterceptorService> _logger;
    private readonly SessionStorageProvider _sessionStorageProvider;
    private readonly NavigationManager _navigationManager;
    public HttpInterceptorService(
        IHttpClientInterceptor interceptor,
        ILogger<HttpInterceptorService> logger, 
        SessionStorageProvider sessionStorageProvider, 
        NavigationManager navigationManager)
    {
        _interceptor = interceptor;
        _logger = logger;
        _sessionStorageProvider = sessionStorageProvider;
        _navigationManager = navigationManager;
    }

    public void RegisterEvent()
    {
        _interceptor.AfterSendAsync += OnAfterSendAsync;
    }

    private async Task OnAfterSendAsync(object sender, HttpClientInterceptorEventArgs e)
    {
        if (e.Response.IsSuccessStatusCode)
            return;

        _logger.LogError("HTTP Error {StatusCode} {ReasonPhrase}",
            e.Response.StatusCode,
            e.Response.ReasonPhrase);

        if (e.Response.StatusCode is HttpStatusCode.Unauthorized)
        {
            await _sessionStorageProvider.RemoveSessionAsync();
            _navigationManager.NavigateTo("/authentication/login");
        }
    }

    public void Dispose()
    {
        _interceptor.AfterSendAsync -= OnAfterSendAsync;
    }
}