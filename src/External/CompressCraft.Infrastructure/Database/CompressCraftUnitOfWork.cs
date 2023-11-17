using CompressCraft.Shared.Database;

namespace CompressCraft.Infrastructure.Database;

internal class CompressCraftUnitOfWork : PostgresUnitOfWork<CompressCraftContext>
{
    public CompressCraftUnitOfWork(CompressCraftContext dbContext)
        : base(dbContext)
    {
    }
}
