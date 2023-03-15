using ApartShare.Application.Interfaces;
using ApartShare.Application.Services;

using Microsoft.Extensions.DependencyInjection;

namespace ApartShare.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IBase64Service, Base64Service>();
        services.AddScoped<IHashService, HashService>();

        return services;
    }
}
