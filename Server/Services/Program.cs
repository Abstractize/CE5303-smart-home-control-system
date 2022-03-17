using Microsoft.Extensions.DependencyInjection;
using Services.Contracts;
using Services.Implementation;

public static class Program
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICameraService, CameraService>();
        services.AddScoped<IHardwareService, HardwareService>();

        return services;
    }
}

