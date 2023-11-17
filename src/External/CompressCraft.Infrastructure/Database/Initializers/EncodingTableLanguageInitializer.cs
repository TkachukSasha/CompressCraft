using CompressCraft.Application.Abstractions.Database;
using CompressCraft.Domain.Encodings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CompressCraft.Infrastructure.Database.Initializers;

internal sealed class EncodingTableLanguageInitializer : IDataInitializer
{
    private readonly CompressCraftContext _context;
    private readonly ILogger<EncodingTableLanguageInitializer> _logger;

    public EncodingTableLanguageInitializer(CompressCraftContext context, ILogger<EncodingTableLanguageInitializer> logger)
        => (_context, _logger) = (context, logger);

    public async Task InitAsync()
    {
        if (await _context.EncodingTableLanguages.AnyAsync()) return;

        await AddEncodingTableLanguagesAsync();

        await _context.SaveChangesAsync();
    }

    private async Task AddEncodingTableLanguagesAsync()
    {
        await _context.EncodingTableLanguages.AddRangeAsync(EncodingTableLanguage.GetValues());

        _logger.LogInformation("Initialized encoding table languages.");
    }
}
