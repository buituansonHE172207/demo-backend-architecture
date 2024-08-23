using DemoBackendArchitecture.Application.Common.Model.User;

namespace DemoBackendArchitecture.Application.Common.Interfaces;

public interface IAuthService
{
    Task<UserSignInResponse> SignIn(UserSignInRequest request);
}