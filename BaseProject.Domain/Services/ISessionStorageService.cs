using BaseProject.Domain.Models;
using Supabase.Gotrue;

namespace BaseProject.Domain.Services;

public interface ISessionStorageService
{
    Task SetSessionAsync(Session session, CancellationToken cancellationToken = default);

    Task<Session?> GetSessionAsync(CancellationToken cancellationToken = default);

    Task RemoveSessionAsync(CancellationToken cancellationToken = default);
}