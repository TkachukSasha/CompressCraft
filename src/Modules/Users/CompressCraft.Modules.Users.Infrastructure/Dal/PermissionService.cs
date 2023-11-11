using CompressCraft.Modules.Users.Domain;
using CompressCraft.Modules.Users.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace CompressCraft.Modules.Users.Infrastructure.Dal;

internal sealed class PermissionService : IPermissionService
{
    private readonly UsersContext _context;

    public PermissionService(UsersContext context)
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
