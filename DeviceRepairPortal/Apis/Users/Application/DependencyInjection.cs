using Application.Common;
using Application.Common.Token;
using Application.Exceptions;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
	{
		services.AddTransient<ITokenService, TokenService>(sp =>
		{
			var userManager = sp.GetRequiredService<UserManager<User>>();
			var jwtSettings = config.GetSection("TokenSettings").Get<TokenSettings>();
			if (jwtSettings is null)
				throw new NotFoundException("TokenSettings are missing.");

			return new TokenService(userManager, jwtSettings);
		});

		services.AddIdentity<User, IdentityRole>(options =>
		{
			options.User.RequireUniqueEmail = true;
			options.Password.RequiredLength = 8;
			options.Password.RequireDigit = true;
			options.Password.RequireUppercase = true;
			options.Password.RequireLowercase = true;
			options.Password.RequireNonAlphanumeric = true;
			options.User.AllowedUserNameCharacters =
				"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
		})
		.AddEntityFrameworkStores<ApplicationDbContext>()
		.AddDefaultTokenProviders();

		services.AddMediatR(cfg =>
		{
			cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
		});

		return services;
	}

}
