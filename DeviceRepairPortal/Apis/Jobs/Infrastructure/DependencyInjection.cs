using Infrastructure.Data;
using Infrastructure.Data.Repositories.Commands;
using Infrastructure.Data.Repositories.Queries;
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
		services.AddRepositories();
		
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

	private static IServiceCollection AddRepositories(this IServiceCollection services)
	{
		services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IReadIssuesRepositories), typeof(ReadIssuesRepositories));
        services.AddScoped(typeof(ITicketReadRepository), typeof(TicketReadRepository));

        services.AddScoped(typeof(ICreateRepository<>), typeof(CreateRepository<>));
		services.AddScoped(typeof(IUpdateRepository<>), typeof(UpdateRepository<>));
        services.AddScoped(typeof(IDeleteRepository<>), typeof(DeleteRepository<>));

        return services;
	}
}
