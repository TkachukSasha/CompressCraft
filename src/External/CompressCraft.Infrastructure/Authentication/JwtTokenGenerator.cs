﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CompressCraft.Application.Abstractions.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace CompressCraft.Infrastructure.Authentication;

internal sealed class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(
        string secretKey,
        string issuer,
        string audience,
        DateTime expiry,
        IEnumerable<Claim> claims
        )
    {
        SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer,
            audience,
            claims,
            DateTime.UtcNow,
            expiry,
            credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
