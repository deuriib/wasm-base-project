using System.Net;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using MudBlazor;
using Toolbelt.Blazor;

namespace BaseProject.Infrastructure.Providers;

public class HttpInterceptorService : IDisposable
{
    private readonly IHttpClientInterceptor _interceptor;
    private readonly ILogger<HttpInterceptorService> _logger;
    private readonly SessionStorageProvider _sessionStorageProvider;
    private readonly NavigationManager _navigationManager;
    private readonly IDialogService _dialogService;
    private readonly ISnackbar _snackbar;
    public HttpInterceptorService(
        IHttpClientInterceptor interceptor,
        ILogger<HttpInterceptorService> logger, 
        SessionStorageProvider sessionStorageProvider, 
        NavigationManager navigationManager, IDialogService dialogService, ISnackbar snackbar)
    {
        _interceptor = interceptor;
        _logger = logger;
        _sessionStorageProvider = sessionStorageProvider;
        _navigationManager = navigationManager;
        _dialogService = dialogService;
        _snackbar = snackbar;
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
            _snackbar.Clear();
            var result = await _dialogService.ShowMessageBox(
                "Your session has expired. Please login again.", 
                "Session Expired", 
                yesText: "Login", noText: null, cancelText: null,
                new DialogOptions
                {
                    CloseButton = false,
                    MaxWidth = MaxWidth.Medium,
                    DisableBackdropClick = true,
                    NoHeader = true,
                    CloseOnEscapeKey = false
                });

            if (result is not null)
            {
                await _sessionStorageProvider.RemoveSessionAsync();
                _navigationManager.NavigateTo("/authentication/login"); 
            }
        }
    }

    public void Dispose()
    {
        _interceptor.AfterSendAsync -= OnAfterSendAsync;
    }
}