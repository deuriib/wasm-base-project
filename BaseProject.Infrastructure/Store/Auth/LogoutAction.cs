namespace BaseProject.Infrastructure.Store.Auth;

public record LogoutAction;

public record LogoutActionSuccess;

public record LogoutActionFailed(string ErrorMessage);