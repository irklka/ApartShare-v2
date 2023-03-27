using ApartShare.Application.Interfaces;
using ApartShare.Application.Services;

using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace ApartShare.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
