using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;

namespace WasmBaseProject.Infrastructure;

public static class InfrastructureInitializer
{
    public static async Task InitializeAsync(WebAssemblyHostConfiguration config)
    {
        await InitializeSupabaseClientAsync(config);
    }

    private static async Task InitializeSupabaseClientAsync(WebAssemblyHostConfiguration config)
    {
        var url = config.GetValue<string>("SupabaseConfig:Url");
        var key = config.GetValue<string>("SupabaseConfig:Key");

        await Supabase.Client.InitializeAsync(url, key);
    }
}