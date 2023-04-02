namespace BaseProject.Infrastructure.Store.Auth;

public sealed record LogoutAction(string ReturnUrl);

public sealed record LogoutActionSuccess(string ReturnUrl);

public sealed record LogoutActionFailed(string ErrorMessage);