using CompressCraft.Modules.Users.Domain;
using CompressCraft.Modules.Users.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompressCraft.Modules.Users.Infrastructure.Dal;

internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(TableNames.Roles);

        builder.HasKey(x => x.Value);

        builder.HasMany(x => x.Permissions)
            .WithMany()
            .UsingEntity<RolePermission>();

        builder.HasMany(x => x.Users)
            .WithMany();

        builder.HasData(Role.GetValues());
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

        IEnumerable<Permission> permissions = Enum
            .GetValues<Core.Abstractions.Abstractions.Authentication.Permission>()
            .Select(p => Permission.Init(new PermissionName(p.ToString())));

        builder.HasData(permissions);
    }
}

internal sealed class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable(TableNames.RolePermissions);

        builder.HasKey(x => new { x.RoleId, x.PermissionId });

        builder.HasData(
             Insert(Role.Admin, Core.Abstractions.Abstractions.Authentication.Permission.AllSections),
             Insert(Role.User, Core.Abstractions.Abstractions.Authentication.Permission.GetAccountInformation),
             Insert(Role.User, Core.Abstractions.Abstractions.Authentication.Permission.ChangedAccountInformation),
             Insert(Role.User, Core.Abstractions.Abstractions.Authentication.Permission.EncodeFiles),
             Insert(Role.User, Core.Abstractions.Abstractions.Authentication.Permission.DecodeFiles),
             Insert(Role.Anonymous, Core.Abstractions.Abstractions.Authentication.Permission.EncodeFiles),
             Insert(Role.Anonymous, Core.Abstractions.Abstractions.Authentication.Permission.DecodeFiles)
        );
    }

    private static RolePermission Insert(
        Role role,
        Core.Abstractions.Abstractions.Authentication.Permission permission)
        => RolePermission.Init(role.Value, (int)permission);
}
