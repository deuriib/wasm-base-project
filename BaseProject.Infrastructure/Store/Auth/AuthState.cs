using System.Text.Json.Serialization;
using Fluxor;
using Fluxor.Persist.Storage;
using Supabase.Gotrue;

namespace BaseProject.Infrastructure.Store.Auth;

[PersistState]
[FeatureState]
public class AuthState
{
    public AuthState(bool isLoading, Session? session)
    {
        IsLoading = isLoading;
        Session = session;
    }

    private AuthState()
    {
        Session = null;
        IsLoading = false;
    }

    public Session? Session { get; }

    [property: JsonIgnore]
    public bool IsLoading { get; }
}