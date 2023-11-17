using CompressCraft.Application.Abstractions.Database;
using CompressCraft.Domain.Users;
using CompressCraft.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CompressCraft.Infrastructure.Database.Initializers;

internal sealed class PermissionInitializer : IDataInitializer
{
    private readonly CompressCraftContext _context;
    private readonly ILogger<PermissionInitializer> _logger;

    public PermissionInitializer(CompressCraftContext context, ILogger<PermissionInitializer> logger)
        => (_context, _logger) = (context, logger);

    public async Task InitAsync()
    {
        if (await _context.Permissions.AnyAsync()) return;

        await AddPermissionsAsync();

        await _context.SaveChangesAsync();
    }

    private async Task AddPermissionsAsync()
    {
        IEnumerable<Permission> permissions = Enum
           .GetValues<Domain.Abstractions.Authentication.Permission>()
           .Select(p => Permission.Init(new PermissionName(p.ToString())).Value);

        await _context.Permissions.AddRangeAsync(permissions);

        _logger.LogInformation("Initialized permissions.");
    }
}
