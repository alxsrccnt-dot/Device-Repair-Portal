using JobManagementApi.Infrastructure;

namespace JobManagementApi;

public static class DependencyInjection
{
	public static IServiceCollection AddWebServices(this IServiceCollection services)
	{
		AddExceptionHandler(services);

		return services;
	}

	private static void AddExceptionHandler(this IServiceCollection services)
	{
		services.AddExceptionHandler<GlobalExceptionHandler>();
		services.AddProblemDetails();
	}
}