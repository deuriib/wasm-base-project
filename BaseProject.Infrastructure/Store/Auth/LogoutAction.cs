namespace BaseProject.Infrastructure.Store.Auth;

public sealed record LogoutAction(string? ReturnUrl = null);

public sealed record LogoutActionSuccess(string? ReturnUrl = null);

public sealed record LogoutActionFailed(string? ErrorMessage = null);