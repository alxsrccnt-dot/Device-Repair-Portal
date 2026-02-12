using FluentValidation;
using UserServices.Infrastructure;

namespace UserServices;

public static class DependencyInjection
{
	public static IServiceCollection AddWebServices(this IServiceCollection services)
	{
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