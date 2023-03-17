using ApartShare.Application.Interfaces.Authentication;
using ApartShare.Application.Interfaces.Repository;
using ApartShare.Application.Interfaces.Services;
using ApartShare.Infrastructure.Authentication;
using ApartShare.Infrastructure.Persistence;
using ApartShare.Infrastructure.Respository;
using ApartShare.Infrastructure.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System.Text;

namespace ApartShare.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddJwtAuthentication(configuration);

        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("Default")));

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services,
        IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SECTION_NAME, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IBase64Service, Base64Service>();
        services.AddScoped<IHashService, PasswordHasher>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(jwtSettings.Secret)),

            });

        return services;
    }


}
