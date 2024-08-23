using DemoBackendArchitecture.Domain.Entities;
using DemoBackendArchitecture.Domain.Interfaces;
using DemoBackendArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DemoBackendArchitecture.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context) : GenericRepository<User>(context), IUserRepository
{
}