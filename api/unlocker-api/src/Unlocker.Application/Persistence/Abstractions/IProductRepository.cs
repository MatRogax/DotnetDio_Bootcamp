using Unlocker.Domain.Entities;


namespace Unlocker.Application.Abstractions.Persistence;

public interface IProductRepository
{
    Task<Guid> CreateAsync(Product product);
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
}