using ApartShare.Application.Interfaces.Repository;
using ApartShare.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace ApartShare.Infrastructure.Respository;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    private readonly ApplicationDbContext _dbContext;

    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<TEntity> GetAll(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return _dbContext.Set<TEntity>().AsNoTracking();
    }

    public async Task<TEntity> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id, cancellationToken);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(TEntity entity, CancellationToken cancellationToken)
    {
        _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var entity = await GetById(id, cancellationToken);
        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
