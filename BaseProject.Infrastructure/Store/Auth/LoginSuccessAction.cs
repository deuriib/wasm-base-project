
using BaseProject.Domain.Models;

namespace BaseProject.Infrastructure.Store.Auth;

public sealed record LoginSuccessAction(Session Session, string ReturnUrl = "/");