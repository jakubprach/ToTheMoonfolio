using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ToTheMoonfolio.Persistence.Configurations;

namespace ToTheMoonfolio.Persistence;

public static class Setup
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseConfiguration(configuration);
        services.ApplyMigrations();
        
        return services;
    }

    private static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseOptions>(configuration.GetSection(nameof(DatabaseOptions)));
        
        services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
        {
            var databaseOptions = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;
            
            options.UseNpgsql(databaseOptions.ConnectionString, serverAction =>
            {
                serverAction.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                serverAction.EnableRetryOnFailure();
                serverAction.CommandTimeout(databaseOptions.CommandTimeout);
            });

            options.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
        });
    }
    
    private static void ApplyMigrations(this IServiceCollection services) {
        using var serviceProvider = services.BuildServiceProvider();
        using var scope = serviceProvider.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
    }
}