
using BaseProject.Domain.Models;
using Supabase.Gotrue;

namespace BaseProject.Infrastructure.Store.Auth;

public sealed record RegisterAction(string Email, string Password);

public sealed record RegisterActionSuccess(Session Session);

public sealed record RegisterActionFailed(string? ErrorMessage = null);