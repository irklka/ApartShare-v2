using ApartShare.Application.Interfaces;
using ApartShare.Application.Interfaces.Services;
using ApartShare.Application.Services;

using Microsoft.Extensions.DependencyInjection;

namespace ApartShare.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
