namespace BaseProject.Infrastructure.Store.Auth;

public sealed record ForgotPasswordAction(string Email);

public sealed record ForgotPasswordResetAction;

public sealed record ForgotPasswordSuccessAction;

public sealed record ForgotPasswordFailAction(string ErrorMessage);