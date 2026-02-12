using FluentValidation;
using JobService.Infrastructure;

namespace JobService;

public static class DependencyInjection
{
	public static IServiceCollection AddWebServices(this IServiceCollection services)
	{
		AddExceptionHandler(services);
		services.AddValidatorsFromAssemblyContaining<Program>();

		return services;
	}

	private static void AddExceptionHandler(this IServiceCollection services)
	{
		services.AddExceptionHandler<GlobalExceptionHandler>();
		services.AddProblemDetails();
	}
}