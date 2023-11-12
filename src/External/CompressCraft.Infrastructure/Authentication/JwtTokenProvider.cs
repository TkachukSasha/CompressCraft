using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CompressCraft.Application.Abstractions.Authentication;
using CompressCraft.Application.Abstractions.Time;
using CompressCraft.Domain.Abstractions.Authentication;

namespace CompressCraft.Infrastructure.Authentication;

internal sealed class JwtTokenProvider : IJwtTokenProvider
{
    private readonly IUtcClock _clock;
    private readonly JwtOptions _jwtOptions;
    private readonly IJwtTokenGenerator _tokenGenerator;

    public JwtTokenProvider(
        IUtcClock clock,
        JwtOptions jwtOptions,
        IJwtTokenGenerator tokenGenerator)
    {
        _clock = clock;
        _jwtOptions = jwtOptions;
        _tokenGenerator = tokenGenerator;
    }

    public JsonWebToken CreateToken(
        string userGid,
        string userName,
        HashSet<string> permissions
        )
    {
        var now = _clock.GetUtcClock();

        var jwtClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userGid),
            new Claim(JwtRegisteredClaimNames.Sub, userGid),
            new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString())
        };

        if (permissions.Any())
        {
            foreach (var permission in permissions)
                jwtClaims.Add(new Claim(CustomClaims.Permissions, permission));
        }

        if (!string.IsNullOrWhiteSpace(userName))
            jwtClaims.Add(new Claim(ClaimTypes.Name, userName));

        var expires = now.AddMinutes(_jwtOptions.ExpiryMinutes);

        var jwt = _tokenGenerator.GenerateToken(
            _jwtOptions.SecretKey,
            _jwtOptions.Issuer,
            _jwtOptions.Audience,
            expires,
            jwtClaims);

        return new JsonWebToken(
            jwt,
            expires.ToTimestamp(),
            userGid,
            jwtClaims);
    }
}
