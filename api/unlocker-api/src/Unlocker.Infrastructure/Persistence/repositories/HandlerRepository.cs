using Unlocker.Application.Persistence.Abstractions;
using Unlocker.Infrastructure.Persistence;

public class GenericRepository<T> : IHandlerRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private IHandlerRepository<T> _handlerRepositoryImplementation;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public Task<T?> GetByIdAsync(Guid id)
    {
        return _handlerRepositoryImplementation.GetByIdAsync(id);
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        return _handlerRepositoryImplementation.GetAllAsync();
    }

    public Task AddAsync(T entity)
    {
        return _handlerRepositoryImplementation.AddAsync(entity);
    }

    public Task UpdateAsync(T entity)
    {
        return _handlerRepositoryImplementation.UpdateAsync(entity);
    }

    public Task DeleteAsync(Guid id)
    {
        return _handlerRepositoryImplementation.DeleteAsync(id);
    }
}