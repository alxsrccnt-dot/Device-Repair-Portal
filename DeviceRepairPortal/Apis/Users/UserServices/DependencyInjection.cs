using Application;
using FluentValidation;
using Infrastructure;
using UserServices.Infrastructure;

namespace UserServices;

internal static class DependencyInjection
{
	internal static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
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

	// internal static IServiceCollection AddSwaggerGenWithAuth(this IServiceCollection services)
	// {
	// 	services.AddSwaggerGen(o =>
	// 	{
	// 		o.CustomSchemaIds(id => id.FullName!.Replace('+', '-'));
	//
	// 		var securityScheme = new OpenApiSecurityScheme
	// 		{
	// 			Name = "JWT Authentication",
	// 			Description = "Enter your JWT token in this field",
	// 			In = ParameterLocation.Header,
	// 			Type = SecuritySchemeType.Http,
	// 			Scheme = JwtBearerDefaults.AuthenticationScheme,
	// 			BearerFormat = "JWT"
	// 		};
	//
	// 		o.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);
	//
	// 		var securityRequirement = new OpenApiSecurityRequirement
	// 		{
	// 			{
	// 				new OpenApiSecurityScheme
	// 				{
	// 					Reference = new OpenApiReference
	// 					{
	// 						Type = ReferenceType.SecurityScheme,
	// 						Id = JwtBearerDefaults.AuthenticationScheme
	// 					}
	// 				},
	// 				[]
	// 			}
	// 		};
	//
	// 		o.AddSecurityRequirement(securityRequirement);
	// 	});
	//
	// 	return services;
	// }
}