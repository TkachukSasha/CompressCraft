using CompressCraft.Domain.Abstractions.Kernel;
using Microsoft.EntityFrameworkCore;

namespace CompressCraft.Infrastructure.Database.Repositories;

internal abstract class Repository<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
    where TEntityId : TypeId
{
    protected readonly CompressCraftContext _dbContext;

    protected Repository(CompressCraftContext dbContext)
        => _dbContext = dbContext;

    public IQueryable<TEntity> GetAll()
        => _dbContext.Set<TEntity>();

    public async Task<TEntity?> GetByIdAsync(
        TEntityId id,
        CancellationToken cancellationToken = default
    ) => await _dbContext
            .Set<TEntity>()
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);

    public void Insert(TEntity entity)
        => _dbContext.Add(entity);

    public void Remove(TEntity entity)
        => _dbContext.Remove(entity);
}
