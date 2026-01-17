using JobMonitoringApi.Infrastructure.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JobMonitoringApi.Infrastructure;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddCustomAuthentification(this IServiceCollection services, IConfiguration config)
	{
		var tokenSettings = config.GetSection("TokenSettings").Get<TokenSettings>();
		services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,

					ValidIssuer = tokenSettings.Issuer,
					ValidAudience = tokenSettings.Audience,

					IssuerSigningKey = new SymmetricSecurityKey(
						Encoding.UTF8.GetBytes(
							tokenSettings.Secret!
						)
					),

					ClockSkew = TimeSpan.Zero
				};

				options.Events = new JwtBearerEvents
				{
					OnAuthenticationFailed = context =>
					{
						context.NoResult();
						context.Response.StatusCode = StatusCodes.Status401Unauthorized;
						context.Response.ContentType = "application/json";

						return context.Response.WriteAsJsonAsync(new
						{
							error = "Invalid or expired token"
						});
					},

					OnChallenge = context =>
					{
						context.HandleResponse();
						context.Response.StatusCode = StatusCodes.Status401Unauthorized;
						context.Response.ContentType = "application/json";

						return context.Response.WriteAsJsonAsync(new
						{
							error = "Authentication required"
						});
					},

					OnForbidden = context =>
					{
						context.Response.StatusCode = StatusCodes.Status403Forbidden;
						context.Response.ContentType = "application/json";

						return context.Response.WriteAsJsonAsync(new
						{
							error = "You do not have permission"
						});
					}
				};
			});
		services.AddAuthorization(options =>
		{
			options.FallbackPolicy = options.DefaultPolicy;
            options.AddPolicy("admins.read", policy =>
                policy.RequireClaim("scope", "admins.read"));

            options.AddPolicy("technicians.read", policy =>
                policy.RequireClaim("scope", "technicians.read"));
        });

		return services;
	}
}