using Supabase.Gotrue;

namespace BaseProject.Infrastructure.Store.Auth;

public record LoginWithEmailAndPasswordAction(string Email, string Password);

public record LoginWithEmailAndPasswordActionSuccess(Session Session);

public record LoginWithEmailAndPasswordActionFailed(string ErrorMessage);