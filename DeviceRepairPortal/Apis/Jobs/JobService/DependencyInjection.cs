using Application;
using FluentValidation;
using Infrastructure;
using JobService.Infrastructure;

namespace JobService;

public static class DependencyInjection
{
	public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddApplication(configuration);
		services.AddInfrastucture(configuration);
		services.AddExceptionHandler();
		services.AddValidatorsFromAssemblyContaining<Program>();

		return services;
	}

	private static void AddExceptionHandler(this IServiceCollection services)
	{
		services.AddExceptionHandler<GlobalExceptionHandler>();
		services.AddProblemDetails();
	}
}