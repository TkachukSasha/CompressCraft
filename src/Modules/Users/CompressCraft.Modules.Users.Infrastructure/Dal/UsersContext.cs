using CompressCraft.Modules.Users.Domain;
using Microsoft.EntityFrameworkCore;

namespace CompressCraft.Modules.Users.Infrastructure.Dal;

public sealed class UsersContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public DbSet<Role> Roles => Set<Role>();

    public DbSet<Permission> Permissions => Set<Permission>();

    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
