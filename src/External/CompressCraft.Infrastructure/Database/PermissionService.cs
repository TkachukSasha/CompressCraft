using CompressCraft.Domain.Users;
using CompressCraft.Domain.Users.Services;
using Microsoft.EntityFrameworkCore;

namespace CompressCraft.Infrastructure.Database;

internal sealed class PermissionService : IPermissionService
{
    private readonly CompressCraftContext _context;

    public PermissionService(CompressCraftContext context)
        => _context = context;

    public async Task<HashSet<string>> GetPermissionsAsync(UserId userId)
    {
        ICollection<Role>[] roles = await _context.Users
            .Include(x => x.Roles)
            .ThenInclude(x => x.Permissions)
            .Where(x => x.Id == userId.Value)
            .Select(x => x.Roles)
            .ToArrayAsync();

        return roles
            .SelectMany(x => x)
            .SelectMany(x => x.Permissions)
            .Select(x => x.PermissionName.Value)
            .ToHashSet();
    }
}
