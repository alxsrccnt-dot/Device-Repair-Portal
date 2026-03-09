using System.Reflection;
using Application.Login;
using Application.Shared;
using Application.Shared.Exceptions;
using Application.Shared.Identity.Token;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Data;
using Infrastructure.Data.Repositories.Commands;
using Infrastructure.Data.Repositories.Queries;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
	{
		services.AddMediatR(cfg =>
		{
			cfg .RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
		});

		services.AddValidatorsFromAssemblyContaining<AuthenticationValidator>();
		
		services.AddTransient<ITokenProvider, TokenProvider>(sp =>
		{
			var userManager = sp.GetRequiredService<UserManager<User>>();
			
			var jwtSettings = config.GetSection("TokenSettings").Get<TokenSettings>();
			if (jwtSettings is null)
				throw new NotFoundException("TokenSettings are missing.");

			return new TokenProvider(userManager, jwtSettings);
		});
		services.AddTransient<IRefreshTokenService, RefreshTokenService>(sp =>
		{
			var readRepository = sp.GetRequiredService<IRefreshTokenReadRepository>();
			var createRepository = sp.GetRequiredService<ICreateRepository<RefreshToken>>();
			var updateRepository = sp.GetRequiredService<IUpdateRepository<RefreshToken> >();
			var currentUser = sp.GetRequiredService<ICurrentUser>();
			
			var jwtSettings = config.GetSection("TokenSettings").Get<TokenSettings>();
			if (jwtSettings is null)
				throw new NotFoundException("TokenSettings are missing.");

			return new RefreshTokenService(readRepository, currentUser, createRepository, updateRepository, jwtSettings.RefreshTokenExpirationInDays);
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
		
		services.AddScoped(typeof(ICurrentUser), typeof(CurrentUser));

		return services;
	}

}
