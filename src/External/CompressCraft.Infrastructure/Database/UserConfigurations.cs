using CompressCraft.Domain.Users;
using CompressCraft.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompressCraft.Infrastructure.Database;

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
            .GetValues<Domain.Abstractions.Authentication.Permission>()
            .Select(p => Permission.Init(new PermissionName(p.ToString())).Value);

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
             Insert(Role.Admin, Domain.Abstractions.Authentication.Permission.AllSections),
             Insert(Role.User, Domain.Abstractions.Authentication.Permission.GetAccountInformation),
             Insert(Role.User, Domain.Abstractions.Authentication.Permission.ChangedAccountInformation),
             Insert(Role.User, Domain.Abstractions.Authentication.Permission.EncodeFiles),
             Insert(Role.User, Domain.Abstractions.Authentication.Permission.DecodeFiles),
             Insert(Role.Anonymous, Domain.Abstractions.Authentication.Permission.EncodeFiles),
             Insert(Role.Anonymous, Domain.Abstractions.Authentication.Permission.DecodeFiles)
        );
    }

    private static RolePermission Insert(
        Role role,
        Domain.Abstractions.Authentication.Permission permission)
        => RolePermission.Init(role.Value, (int)permission);
}
