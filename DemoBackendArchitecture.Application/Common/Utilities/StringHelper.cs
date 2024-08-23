using DemoBackendArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace DemoBackendArchitecture.Application.Common.Utilities;

public static class StringHelper
{
    public static string Hash(this string inputString)
    {
        PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
        return passwordHasher.HashPassword(null!, inputString);
    }
    public static bool Verify(User user, string pass)
    {
        PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
         return passwordHasher.VerifyHashedPassword(user, user.Password!, pass) == PasswordVerificationResult.Success;
    }
        
}