using Microsoft.AspNetCore.Components;

namespace BaseProject.Infrastructure.Extensions;

public static class NavigationManagerExtensions
{
    public static void NavigateToUri(this NavigationManager navigationManager,
        string url,
        bool forceLoad = false,
        bool replaceHistoryEntry = false)
    {
        navigationManager
            .NavigateTo($"{navigationManager.BaseUri}{Uri.EscapeDataString(url)}",
                forceLoad,
                replaceHistoryEntry);
    }
}