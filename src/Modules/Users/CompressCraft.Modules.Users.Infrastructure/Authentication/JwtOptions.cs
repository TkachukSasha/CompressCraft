namespace CompressCraft.Modules.Users.Infrastructure.Authentication;

public class JwtOptions
{
    public string SecretKey { get; set; } = default!;

    public string Issuer { get; set; } = default!;

    public string Audience { get; set; } = default!;

    public int ExpiryMinutes { get; set; }

    public bool ValidateIssuer { get; set; }

    public bool ValidateAudience { get; set; }
}
