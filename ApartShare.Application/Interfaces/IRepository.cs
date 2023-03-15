namespace ApartShare.Application.Interfaces;

public interface IRepository<TEntity> 
    where TEntity : class
{
    IQueryable<TEntity> GetAll(CancellationToken cancellationToken);

    Task<TEntity> GetById(Guid id, CancellationToken cancellationToken);

    Task AddAsync(TEntity entity, CancellationToken cancellationToken);

    Task Update(TEntity entity, CancellationToken cancellationToken);

    Task Delete(Guid id, CancellationToken cancellationToken);
}
