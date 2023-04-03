namespace BaseProject.Domain.Services;

public interface IHttpInterceptorService
{
    void RegisterEvent();
    void UnregisterEvent();
}