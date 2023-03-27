using Supabase.Gotrue;

namespace BaseProject.Infrastructure.Store.Auth;

public record LoginWithGoogleAction;
public record LoginWithGoogleActionSuccess(Session Session);
public record LoginWithGoogleActionFailed(string ErrorMessage);