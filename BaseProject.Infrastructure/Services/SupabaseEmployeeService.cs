using System.Net.Http.Headers;
using System.Net.Http.Json;
using BaseProject.Domain.Models;
using BaseProject.Domain.Services;
using BaseProject.Infrastructure.Providers;

namespace BaseProject.Infrastructure.Services;

public sealed class SupabaseEmployeeService : IEmployeeService
{
    private readonly HttpClient _httpClient;
    private readonly ISessionStorageService _sessionStorageService;

    public SupabaseEmployeeService(
        IHttpClientFactory httpClientFactory,
        ISessionStorageService sessionStorageService)
    {
        _httpClient = httpClientFactory
            .CreateClient("Supabase");

        _sessionStorageService = sessionStorageService;
    }

    public async ValueTask<IReadOnlyList<Employee>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        await SetAuthorizationHeaderAsync(cancellationToken);

        return await _httpClient
            .GetFromJsonAsync<Employee[]>(
                "rest/v1/employees?select=id,name,last_name,email,status",
                cancellationToken);
    }

    public async ValueTask<Employee?> GetOneAsync(long id, CancellationToken cancellationToken = default)
    {
        await SetAuthorizationHeaderAsync(cancellationToken);

        var model = await _httpClient
            .GetFromJsonAsync<Employee[]>(
                $"rest/v1/employees?id=eq.{id}&select=*&limit=1",
                cancellationToken);

        return model?.SingleOrDefault();
    }

    public async ValueTask<Employee?> CreateAsync(
        Employee employee,
        CancellationToken cancellationToken = default)
    {
        await SetAuthorizationHeaderAsync(cancellationToken);
        
        _httpClient
            .DefaultRequestHeaders
            .Add("Prefer", "return=representation");

        var response = await _httpClient
            .PostAsJsonAsync<Employee>("rest/v1/employees", employee, cancellationToken);

        response
            .EnsureSuccessStatusCode();
        
        return await response
            .Content
            .ReadFromJsonAsync<Employee>(cancellationToken: cancellationToken);
    }

    public async Task UpdateAsync(
        long id,
        Employee employee,
        CancellationToken cancellationToken = default)
    {
        await SetAuthorizationHeaderAsync(cancellationToken);

        var response = await _httpClient
            .PatchAsJsonAsync($"rest/v1/employees?id=eq.{id}", employee, cancellationToken);

        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        await SetAuthorizationHeaderAsync(cancellationToken);

        var response = await _httpClient
            .DeleteAsync($"rest/v1/employees?id=eq.{id}", cancellationToken);

        response.EnsureSuccessStatusCode();
    }

    private async Task SetAuthorizationHeaderAsync(CancellationToken cancellationToken = default)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            (await _sessionStorageService
                .GetSessionAsync(cancellationToken))!
            .TokenType!,
            (await _sessionStorageService
                .GetSessionAsync(cancellationToken))!
            .AccessToken);
    }
}