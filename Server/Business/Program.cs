using Business.Managers.Contracts;
using Business.Managers.Implementation;
using Microsoft.Extensions.DependencyInjection;

public static class Program
{
    public static IServiceCollection AddManagers(this IServiceCollection services)
    {
        services.AddScoped<IAuthManager, AuthManager>();
        services.AddScoped<IHelloHarwareManager, HelloHarwareManager>();

        return services;
    }
}

