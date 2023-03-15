using System.Reflection;

namespace ApartShare.Web;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWeb(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}