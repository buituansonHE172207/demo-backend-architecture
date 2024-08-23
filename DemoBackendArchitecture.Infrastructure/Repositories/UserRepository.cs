using DemoBackendArchitecture.Domain.Entities;
using DemoBackendArchitecture.Domain.Interfaces;
using DemoBackendArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DemoBackendArchitecture.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context) : GenericRepository<User>(context), IUserRepository
{
    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await context.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Email == email);
    }
}