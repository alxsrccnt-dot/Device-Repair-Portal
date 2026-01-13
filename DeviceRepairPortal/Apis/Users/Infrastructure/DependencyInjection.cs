using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
	private readonly static string _databaseConnectionString = "DatabaseContext";

	public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration config)
	{
		services.AddDatabaseContext(config);
		
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
}
