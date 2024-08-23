namespace DemoBackendArchitecture.Application.Common.Interfaces;

public interface ICookieService
{
    void Set(string token);
    string Get();
    void Delete();
}