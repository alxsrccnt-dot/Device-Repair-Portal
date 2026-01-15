using DeviceRepairPortal.Infrastructure.ApisClients;
using DeviceRepairPortal.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace DeviceRepairPortal.Infrastructure;

public static class DependencyInjection
{
    private const string UserServiceBaseUrlKey = "UrlsSettings:UserServiceBaseUrl";

    public static IServiceCollection AddWebsiteInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddCustomAuthentication();
        services.AddHttpClients(config);

        return services;
    }

    private static void AddHttpClients(this IServiceCollection services, IConfiguration config)
    {
        services.AddHttpClient<IAuthServicesClient, AuthServiceClient>((sp, c) =>
        {
            var userServiceBaseUrl = config[UserServiceBaseUrlKey];
            if (userServiceBaseUrl == null)
                throw new NotFoundException("UserServiceBaseUrl is missing.");

            c.BaseAddress = new Uri(config[UserServiceBaseUrlKey]);
        });
    }

    private static void AddCustomAuthentication(this IServiceCollection services)
    {
        services
        .AddAuthentication("Bearer")
        .AddJwtBearer("Bearer", options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
            };

            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    context.Token = context.Request.Cookies["access_token"];
                    return Task.CompletedTask;
                }
            };
        });
    }
}