using Supabase.Gotrue;

namespace BaseProject.Infrastructure.Store.Auth;

public record LoginSuccessAction(Session Session);