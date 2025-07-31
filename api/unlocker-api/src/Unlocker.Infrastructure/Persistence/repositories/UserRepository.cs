using Microsoft.EntityFrameworkCore;
using Unlocker.Application.Abstractions.Persistence;
using Unlocker.Domain.Entities;

namespace Unlocker.Infrastructure.Persistence.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<Guid> CreateAsync(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return user.Id;
    }

    public async Task<User?> GetByEmailAsync(string email) =>
        await context.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task<List<User>> GetAllAsync() =>
        await context.Users.ToListAsync();

    public async Task<User?> GetByIdAsync(Guid id) =>
        await context.Users.FindAsync(id);
}