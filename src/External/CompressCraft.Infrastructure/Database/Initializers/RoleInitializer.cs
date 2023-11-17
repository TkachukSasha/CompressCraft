using CompressCraft.Application.Abstractions.Database;
using CompressCraft.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CompressCraft.Infrastructure.Database.Initializers;

internal sealed class RoleInitializer : IDataInitializer
{
    private readonly CompressCraftContext _context;
    private readonly ILogger<RoleInitializer> _logger;

    public RoleInitializer(CompressCraftContext context, ILogger<RoleInitializer> logger)
        => (_context, _logger) = (context, logger);

    public async Task InitAsync()
    {
        if (await _context.Roles.AnyAsync()) return;

        await AddRolesAsync();

        await _context.SaveChangesAsync();
    }

    private async Task AddRolesAsync()
    {
        await _context.Roles.AddRangeAsync(Role.GetValues());

        _logger.LogInformation("Initialized roles.");
    }
}
