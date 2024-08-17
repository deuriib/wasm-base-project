using Supabase.Gotrue;

namespace BaseProject.Domain.Services;

public interface IAuthenticationService : IService
{
    ValueTask<Session?> SignInWithEmailAndPasswordAsync(
        string email,
        string password,
        CancellationToken cancellationToken = default);

    Task SignOutAsync(CancellationToken cancellationToken = default);

    ValueTask<Session?> SignInWithPhoneAsync(
        string phoneNumber,
        CancellationToken cancellationToken = default);

    ValueTask<Session?> VerifyPhoneAsync(
        string phoneNumber,
        string opt,
        CancellationToken cancellationToken = default);

    ValueTask<Session?> SignUpAsync(
        string email,
        string password,
        CancellationToken cancellationToken = default);

    ValueTask<bool> SendPasswordResetEmailAsync(
        string email,
        CancellationToken cancellationToken = default);
}