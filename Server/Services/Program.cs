using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Contracts;
using Services.Implementation;

public static class Program
{
    private static readonly string SYS_PATH_NAME = "SYS_PATH";
    private static readonly string SYS_PATH_DEBUG = "./bin/Debug/net6.0/linux-x64/gpio";
    private static readonly string SYS_PATH_RELEASE = "/sys/class/gpio";
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IHardwareService, HardwareService>();
        services.AddScoped<ITimerService, TimerService>();

        return services;
    }

    public static IWebHostEnvironment AddEnvironmentVariables(this IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
            Environment.SetEnvironmentVariable(SYS_PATH_NAME, SYS_PATH_DEBUG);
        else
            Environment.SetEnvironmentVariable(SYS_PATH_NAME, SYS_PATH_RELEASE);

        return environment;
    }
}

