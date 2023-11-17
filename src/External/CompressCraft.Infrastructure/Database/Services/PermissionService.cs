using CompressCraft.Domain.Users;
using CompressCraft.Domain.Users.Services;
using Microsoft.EntityFrameworkCore;

namespace CompressCraft.Infrastructure.Database.Services;

internal sealed class PermissionService : IPermissionService
{
    private readonly CompressCraftContext _context;

    public PermissionService(CompressCraftContext context)
        => _context = context;

    public async Task<HashSet<string>> GetPermissionsAsync(UserId userId)
    {
        UserRole[]? userRoles = await _context.UserRoles
            .Where(x => x.UserId == userId)
            .ToArrayAsync();

        if (!userRoles.Any())
            return new HashSet<string>();

        List<Role> roles = await _context.Roles
            .Where(x => userRoles.Any(ur => ur.RoleId == x.Value))
            .Include(x => x.Permissions)
            .ToListAsync();

        return roles
            .SelectMany(x => x.Permissions)
            .Select(x => x.PermissionName.Value)
            .ToHashSet();
    }
}
