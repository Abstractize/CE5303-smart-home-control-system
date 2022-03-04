using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using Data.Accessors.Contracts;
using Data.Accessors.Implementation;
using Microsoft.AspNetCore.Identity;

public static class Program
{
    public static IServiceCollection AddDatabase<TAuth>(this IServiceCollection services, String? connectionString = null) where TAuth : UserManager<User>
    {
        if (String.IsNullOrEmpty(connectionString))
            throw new ArgumentNullException(nameof(connectionString));

        services.AddDbContext<HomeContext>(options
            => options.UseSqlite(connectionString));

        services.AddAuthentication()
            .AddIdentityServerJwt();

        services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
            options.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<HomeContext>()
        .AddUserManager<TAuth>()
        .AddDefaultTokenProviders();

        services.AddIdentityServer()
            .AddApiAuthorization<User, HomeContext>();

        return services;
    }
    public static IServiceCollection AddAccessors(this IServiceCollection services)
    {
        services.AddScoped<IUserAccessor, UserAccessor>();

        return services;
    }
    public static IServiceProvider AddMigrationAndSeed(this IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            var database = scope.ServiceProvider.GetService<HomeContext>().Database;
            if (database.IsRelational())
                database.Migrate();
        }

        return services;
    }
}

