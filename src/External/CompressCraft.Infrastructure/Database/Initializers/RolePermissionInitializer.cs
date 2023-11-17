using CompressCraft.Application.Abstractions.Database;
using CompressCraft.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CompressCraft.Infrastructure.Database.Initializers;

internal sealed class RolePermissionInitializer : IDataInitializer
{
    private readonly CompressCraftContext _context;
    private readonly ILogger<RolePermissionInitializer> _logger;

    public RolePermissionInitializer(CompressCraftContext context, ILogger<RolePermissionInitializer> logger)
        => (_context, _logger) = (context, logger);

    public async Task InitAsync()
    {
        if (await _context.RolePermissions.AnyAsync()) return;

        await AddRolePermissionsAsync();

        await _context.SaveChangesAsync();
    }

    private async Task AddRolePermissionsAsync()
    {
        IEnumerable<RolePermission> rolePermissions = new List<RolePermission>()
        {
            Insert(Role.Admin, Domain.Abstractions.Authentication.Permission.AllSections),
            Insert(Role.Participant, Domain.Abstractions.Authentication.Permission.GetAccountInformation),
            Insert(Role.Participant, Domain.Abstractions.Authentication.Permission.ChangedAccountInformation)
        };

        await _context.RolePermissions.AddRangeAsync(rolePermissions);

        _logger.LogInformation("Initialized role permissions.");
    }

    private static RolePermission Insert(
      Role role,
      Domain.Abstractions.Authentication.Permission permission
    ) => RolePermission.Init(role.Value, (int)permission);
}
