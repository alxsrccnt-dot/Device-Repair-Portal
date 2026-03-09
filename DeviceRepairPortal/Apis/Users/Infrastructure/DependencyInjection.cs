using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Infrastructure.Data;
using Infrastructure.Data.Repositories.Commands;
using Infrastructure.Data.Repositories.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    private static readonly string _databaseConnectionString = "DatabaseContext";
    private static readonly string _serviceBusConnectionString = "ServiceBusConnectionString";

    public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration config)
    {
        services.AddDatabaseContext(config);
        services.AddServiceBus(config);
        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            var connectionString = config.GetConnectionString(_databaseConnectionString);

            options.UseSqlServer(connectionString,
                sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                    sqlOptions.EnableRetryOnFailure(
                        5,
                        TimeSpan.FromSeconds(30),
                        null);
                });
        });

        return services;
    }

    private static void AddServiceBus(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString(_serviceBusConnectionString);
        //services.AddScoped<INotificationServiceBus, NotificationServiceBus>();
        services.AddSingleton<ServiceBusClient>(serviceProvider =>
        {
            var config = serviceProvider.GetRequiredService<IConfiguration>();
            return new ServiceBusClient(connectionString, new DefaultAzureCredential());
        });
    }
    
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IRefreshTokenReadRepository), typeof(RefreshTokenReadRepository));
        services.AddScoped(typeof(IUserReadRepository), typeof(UserReadRepository));

        services.AddScoped(typeof(ICreateRepository<>), typeof(CreateRepository<>));
        services.AddScoped(typeof(IUpdateRepository<>), typeof(UpdateRepository<>));
        services.AddScoped(typeof(IDeleteRepository<>), typeof(DeleteRepository<>));

        return services;
    }
}