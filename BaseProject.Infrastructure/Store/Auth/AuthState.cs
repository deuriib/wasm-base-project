using System.Text.Json.Serialization;
using Fluxor;
using Fluxor.Persist.Storage;
using MudBlazor;
using Supabase.Gotrue;

namespace BaseProject.Infrastructure.Store.Auth;

[PersistState]
[FeatureState]
public sealed record AuthState(
    bool IsLoading,
    bool IsEmailForgotPasswordSent,
    bool IsPasswordVisible,
    Session? Session,
    string? ErrorMessage)
{
    public AuthState() : this(false, false, false, null, null)
    {
    }
}
