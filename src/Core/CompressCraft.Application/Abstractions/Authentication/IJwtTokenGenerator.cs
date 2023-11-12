using System.Security.Claims;

namespace CompressCraft.Application.Abstractions.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(
        string secretKey,
        string issuer,
        string audience,
        DateTime expiry,
        IEnumerable<Claim> claims
    );
}
