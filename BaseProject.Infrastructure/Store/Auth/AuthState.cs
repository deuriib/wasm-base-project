using System.Text.Json.Serialization;
using BaseProject.Domain.Models;
using Fluxor;
using Fluxor.Persist.Storage;
using MudBlazor;

namespace BaseProject.Infrastructure.Store.Auth;

[PersistState]
[FeatureState]
public sealed record AuthState(bool IsLoading, 
    Session? Session, 
    bool IsEmailForgotPasswordSent,
    string ErrorMessage = "")
{
    private AuthState()
    : this(false, null, false)
    {
    }
}