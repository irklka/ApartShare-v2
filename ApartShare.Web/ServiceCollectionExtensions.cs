using ApartShare.Application.Models;

using FluentValidation;

using Microsoft.OpenApi.Models;

using System.Reflection;

namespace ApartShare.Web;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWeb(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<Base64Options>(configuration.GetSection(Base64Options.SECTION_NAME));

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddEndpointsApiExplorer()
            .AddSwaggerGen(options =>
            {
                var securityScheme = new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                };

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "bearerAuth"
                            }
                        },
                        new string[] { }
                    }
                };

                options.AddSecurityDefinition("bearerAuth", securityScheme);
                options.AddSecurityRequirement(securityRequirement);
            });

        return services;
    }
}
