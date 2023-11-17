using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CompressCraft.Infrastructure.Database.Options;

internal sealed class PostgresOptionsSetup : IConfigureOptions<PostgresOptions>
{
    private readonly IConfiguration _configuration;

    public PostgresOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(PostgresOptions options)
    {
        if (options is not null)
        {
            var connectionString = _configuration.GetConnectionString("postgres_connection");

            if (!string.IsNullOrWhiteSpace(connectionString))
                options.PostgresConnection = connectionString;

            _configuration.GetSection("postgres").Bind(options);
        }
    }
}
