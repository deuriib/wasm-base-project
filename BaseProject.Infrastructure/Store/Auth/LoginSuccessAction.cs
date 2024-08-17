
using BaseProject.Domain.Models;
using Supabase.Gotrue;

namespace BaseProject.Infrastructure.Store.Auth;

public sealed record LoginSuccessAction(Session Session, string? ReturnUrl = null);