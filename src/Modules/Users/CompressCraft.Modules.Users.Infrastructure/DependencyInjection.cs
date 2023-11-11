using System.Text;
using CompressCraft.Core;
using CompressCraft.Core.Time;
using CompressCraft.Modules.Users.Domain.Services;
using CompressCraft.Modules.Users.Features.Abstractions.Authentication;
using CompressCraft.Modules.Users.Infrastructure.Authentication;
using CompressCraft.Modules.Users.Infrastructure.Dal;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CompressCraft.Modules.Users.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPermissionService(this IServiceCollection services)
        => services.AddScoped<IPermissionService, PermissionService>();

    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtOptions = configuration.BindOptions<JwtOptions>("security");

        services.AddSingleton(jwtOptions);

        services.AddTime();

        services.AddScoped<IPasswordManager, PasswordManager>();
        services.AddScoped<IJwtTokenProvider, JwtTokenProvider>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey));

                jwt.SaveToken = true;

                jwt.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = issuerSigningKey,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    ValidateIssuer = true,
                    ValidateAudience = true
                };
            });

        services.AddAuthorization();

        services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

        return services;
    }
}
