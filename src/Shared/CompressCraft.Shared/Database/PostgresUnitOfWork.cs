using CompressCraft.Shared.Abstractions.Database;
using Microsoft.EntityFrameworkCore;

namespace CompressCraft.Shared.Database;

public abstract class PostgresUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
{
    private readonly TContext _dbContext;

    protected PostgresUnitOfWork(TContext dbContext) => _dbContext = dbContext;

    public async Task ExecuteAsync(Func<Task> action)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            await action();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
