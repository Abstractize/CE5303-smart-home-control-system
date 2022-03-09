using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using Data.Accessors.Contracts;
using Data.Accessors.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;

public static class Program
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, String connectionString = null)
    {
        if (String.IsNullOrEmpty(connectionString))
            throw new ArgumentNullException(nameof(connectionString));

        services.AddDbContext<HomeContext>(options
            => options.UseSqlite(connectionString));

        services.AddAuthentication()
            .AddIdentityServerJwt();

        services.AddIdentity<User, Role>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;

            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
            
            options.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<HomeContext>()
        .AddDefaultTokenProviders();

        services.AddIdentityServer()
            .AddApiAuthorization<User, HomeContext>();

        return services;
    }
    public static IServiceCollection AddAccessors(this IServiceCollection services)
    {
        services.AddScoped<IDoorAccessor, DoorAccessor>();
        services.AddScoped<ILightAccessor, LightAccessor>();
        services.AddScoped<IPhotoAccessor, PhotoAccessor>();

        return services;
    }
    public static IServiceProvider AddMigrationAndSeed(this IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            DatabaseFacade database = scope.ServiceProvider.GetService<HomeContext>().Database;
            if (database.IsRelational())
                database.Migrate();
        }

        return services;
    }
}

