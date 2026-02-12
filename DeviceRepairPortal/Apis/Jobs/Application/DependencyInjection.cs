using Application.Management.Jobs;
using Application.Services;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
	{
		services.AddMediatR(cfg =>
		{
			cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
		});
		services.AddServicesCollection();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
		services.AddValidatorsFromAssemblyContaining<CreateJobValidator>();

		return services;
    }

    private static IServiceCollection AddServicesCollection(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped(typeof(ICurrentUser), typeof(CurrentUser));
        return services;
    }
}
