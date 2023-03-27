using Supabase.Gotrue;

namespace BaseProject.Infrastructure.Store.Auth;

public record RegisterAction(string Email, string Password);

public record RegisterActionSuccess(Session Session);

public record RegisterActionFailed(string ErrorMessage);