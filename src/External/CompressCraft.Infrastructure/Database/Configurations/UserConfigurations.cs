using CompressCraft.Domain.Users;
using CompressCraft.Domain.Users.ValueObjects;
using CompressCraft.Infrastructure.Database.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompressCraft.Infrastructure.Database.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(TableNames.Users);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
           .HasConversion(x => x.Value, x => new UserId());

        builder.Property(x => x.UserName)
            .HasConversion(x => x.Value, x => new UserName(x));

        builder.Property(x => x.Password)
            .HasConversion(x => x.Value, x => new Password(x));

        builder.HasIndex(x => x.UserName);
    }
}

internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(TableNames.Roles);

        builder.HasKey(x => x.Value);

        builder.HasMany(x => x.Permissions)
            .WithMany()
            .UsingEntity<RolePermission>();
    }
}

internal sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable(TableNames.Permissions);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
          .HasConversion(x => x.Value, x => new PermissionId());

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new PermissionId());
    }
}

internal sealed class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable(TableNames.RolePermissions);

        builder.HasKey(x => new { x.RoleId, x.PermissionId });
    }
}

internal sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable(TableNames.UserRoles);

        builder.HasKey(x => new { x.RoleId, x.UserId });

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.Role)
            .WithMany()
            .HasForeignKey(x => x.RoleId);
    }
}
