namespace BaseProject.Infrastructure.Store.Auth;

public record LogoutAction(string ReturnUrl);

public record LogoutActionSuccess(string ReturnUrl);

public record LogoutActionFailed(string ErrorMessage);