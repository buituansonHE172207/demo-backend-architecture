using DemoBackendArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace DemoBackendArchitecture.Application.Common.Utilities;

public static class StringHelper
{

    public static bool Verify(User user, string pass)
    {
        PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
         return _passwordHasher.VerifyHashedPassword(user, user.Password!, pass) == PasswordVerificationResult.Success;
    }
        
}