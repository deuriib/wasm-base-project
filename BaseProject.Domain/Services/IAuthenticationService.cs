using BaseProject.Domain.Models;

namespace BaseProject.Domain.Services;

public interface IAuthenticationService : IService
{
    ValueTask<Session?> SignInWithEmailAndPasswordAsync(
        string email, 
        string password, 
        CancellationToken cancellationToken = default);
    
    Task SignOutAsync(CancellationToken cancellationToken = default);
    
    Task SignInWithPhoneAsync(
        string phoneNumber,
        CancellationToken cancellationToken = default);
    
    ValueTask<Session?> VerifyPhoneAsync(
        string phoneNumber, 
        string code,
        CancellationToken cancellationToken = default);

    ValueTask<Session?> SignUpAsync(
        string email, 
        string password,
        CancellationToken cancellationToken = default);
    
    Task SendPasswordResetEmailAsync(
        string email,
        CancellationToken cancellationToken = default);
}