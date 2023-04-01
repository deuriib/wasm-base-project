
using BaseProject.Domain.Models;

namespace BaseProject.Infrastructure.Store.Auth;

public record LoginSuccessAction(Session Session, string ReturnUrl = "/");