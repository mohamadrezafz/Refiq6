using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refiq6.Application.Interfaces;
using Refiq6.Infrastructure.Persistance;

namespace Refiq6.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services
        , IConfiguration configuration
    )
    {

        services.AddScoped<IApplicationDatabaseContext>(provider => provider.GetRequiredService<ApplicationDatabaseContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDatabaseContext>(options =>
            options.UseSqlite(
                connectionString,
                    builder => builder.MigrationsAssembly(typeof(ApplicationDatabaseContext).Assembly.FullName)
                )
        );


        return services;
    }
}
