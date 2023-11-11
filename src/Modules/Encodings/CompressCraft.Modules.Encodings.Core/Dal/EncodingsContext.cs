using CompressCraft.Modules.Encodings.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CompressCraft.Modules.Encodings.Core.Dal;

public class EncodingsContext : DbContext
{
    public DbSet<EncodingTable> EncodingTables => Set<EncodingTable>();

    public DbSet<EncodingTableLanguage> EncodingTableLanguages => Set<EncodingTableLanguage>();

    public DbSet<EncodingAlgorithm> EncodingAlgorithms => Set<EncodingAlgorithm>();

    public EncodingsContext(DbContextOptions<EncodingsContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EncodingsContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
