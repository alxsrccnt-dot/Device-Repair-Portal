using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
	private readonly static string _databaseConnectionString = "DatabaseContext";
	private readonly static string _serviceBusConnectionString = "ServiceBusConnectionString";

    public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration config)
	{
		services.AddDatabaseContext(config);
		services.AddServiceBus(config);

        return services;
	}

	private static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration config)
	{
		services.AddDbContext<ApplicationDbContext>( options =>
		{
			string? connectionString = config.GetConnectionString(_databaseConnectionString);

			options.UseSqlServer(connectionString,
				sqlOptions =>
				{
					sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
					sqlOptions.EnableRetryOnFailure(
						maxRetryCount: 5,
						maxRetryDelay: TimeSpan.FromSeconds(30),
						errorNumbersToAdd: null);
				});
		});

		return services;
	}

    private static void AddServiceBus(this IServiceCollection services, IConfiguration config)
    {
        string? connectionString = config.GetConnectionString(_serviceBusConnectionString);
        //services.AddScoped<INotificationServiceBus, NotificationServiceBus>();
        services.AddSingleton<ServiceBusClient>(serviceProvider =>
        {
            var config = serviceProvider.GetRequiredService<IConfiguration>();
            return new ServiceBusClient(connectionString, new DefaultAzureCredential());
        });
    }
}
