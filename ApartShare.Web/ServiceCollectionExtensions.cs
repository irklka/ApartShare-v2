using ApartShare.Application.Models;

using System.Reflection;

namespace ApartShare.Web;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWeb(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<Base64Options>(configuration.GetSection(Base64Options.SECTION_NAME));

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}
