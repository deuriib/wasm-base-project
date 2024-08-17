using System.Net.Http.Json;
using BaseProject.Domain.Services;
using Microsoft.Extensions.Logging;
using Supabase.Gotrue;

namespace BaseProject.Infrastructure.Services;

public sealed class SupabaseAuthenticationService(ILogger<SupabaseAuthenticationService> logger, Client supabase) : IAuthenticationService
{
    public async ValueTask<Session?> SignInWithEmailAndPasswordAsync(string email, string password,
        CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Signing with email and password");

        return await supabase.SignIn(email, password);
    }

    public async Task SignOutAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Signing out");

        await supabase.SignOut();
    }

    public async ValueTask<Session?> SignInWithPhoneAsync(
        string phoneNumber,
        CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Signing in with phone");

        return await supabase.SignIn(Constants.SignInType.Phone, phoneNumber);
    }

    public async ValueTask<Session?> VerifyPhoneAsync(
        string phoneNumber,
        string opt,
        CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Verifying phone");
        return await supabase.VerifyOTP(phoneNumber, opt, Constants.MobileOtpType.SMS);
    }

    public async ValueTask<Session?> SignUpAsync(
        string email,
        string password,
        CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Signing up");
        return await supabase.SignUp(email, password);
    }

    public async ValueTask<bool> SendPasswordResetEmailAsync(
        string email,
        CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Sending password reset email");

        return await supabase.ResetPasswordForEmail(email);
    }
}