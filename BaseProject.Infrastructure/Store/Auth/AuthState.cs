using System.Text.Json.Serialization;
using BaseProject.Domain.Models;
using Fluxor;
using Fluxor.Persist.Storage;

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