using Supabase.Gotrue;

namespace BaseProject.Domain.Services;

public interface IAuthenticationService
{
    ValueTask<Session?> SignInWithEmailAndPasswordAsync(string email, string password);
    
    Task SignOutAsync();
    
    ValueTask<Session?> SignInWithPhoneAndPasswordAsync(string phoneNumber, string password);
    
    ValueTask<Session?> SignInWithGoogleAsync();
    
    ValueTask<Session?> GetCurrentSessionAsync();
    
    ValueTask<Session?> SignUpAsync(string email, string password);
    
    ValueTask<User?> GetUserFromJwtAsync(string jwt);
    
    Session? SetSessionFromAccessToken(string accessToken);
}