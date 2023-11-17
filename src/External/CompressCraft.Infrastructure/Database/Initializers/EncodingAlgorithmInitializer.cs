using CompressCraft.Application.Abstractions.Database;
using CompressCraft.Domain.Encodings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CompressCraft.Infrastructure.Database.Initializers;

internal sealed class EncodingAlgorithmInitializer : IDataInitializer
{
    private readonly CompressCraftContext _context;
    private readonly ILogger<EncodingAlgorithmInitializer> _logger;

    public EncodingAlgorithmInitializer(CompressCraftContext context, ILogger<EncodingAlgorithmInitializer> logger)
        => (_context, _logger) = (context, logger);

    public async Task InitAsync()
    {
        if (await _context.EncodingAlgorithms.AnyAsync()) return;

        await AddEncodingAlgorithmsAsync();

        await _context.SaveChangesAsync();
    }

    private async Task AddEncodingAlgorithmsAsync()
    {
        await _context.EncodingAlgorithms.AddRangeAsync(EncodingAlgorithm.GetValues());

        _logger.LogInformation("Initialized encoding algorithms.");
    }
}
