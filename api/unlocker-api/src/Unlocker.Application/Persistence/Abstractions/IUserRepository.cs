using Unlocker.Domain.Entities;

namespace Unlocker.Application.Abstractions.Persistence;

public interface IUserRepository
{
    Task<Guid> CreateAsync(User user);
    Task<User?> GetByEmailAsync(string email);
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid id);
}