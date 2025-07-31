using Unlocker.Application.Persistence.Abstractions;
using Unlocker.Domain.Entities;

namespace Unlocker.Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    public Task<Product?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}