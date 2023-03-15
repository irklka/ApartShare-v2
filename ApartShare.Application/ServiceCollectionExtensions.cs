using ApartShare.Application.Interfaces;
using ApartShare.Application.Models;
using ApartShare.Application.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApartShare.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.Configure<Base64>(options => configuration.GetSection(nameof(Base64)));
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IBase64Service, Base64Service>();

        return services;
    }
}
