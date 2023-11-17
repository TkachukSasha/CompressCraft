using CompressCraft.Domain.Encodings;
using CompressCraft.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace CompressCraft.Infrastructure.Database;

public sealed class CompressCraftContext : DbContext
{
    public DbSet<EncodingTable> EncodingTables => Set<EncodingTable>();

    public DbSet<EncodingTableLanguage> EncodingTableLanguages => Set<EncodingTableLanguage>();

    public DbSet<EncodingAlgorithm> EncodingAlgorithms => Set<EncodingAlgorithm>();

    public DbSet<User> Users => Set<User>();

    public DbSet<Role> Roles => Set<Role>();

    public DbSet<Permission> Permissions => Set<Permission>();

    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();

    public DbSet<UserRole> UserRoles => Set<UserRole>();

    public CompressCraftContext(
        DbContextOptions<CompressCraftContext> options
        ) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompressCraftContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
