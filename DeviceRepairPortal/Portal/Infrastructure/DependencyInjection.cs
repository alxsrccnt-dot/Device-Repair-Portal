using Infrastructure.ApisClients.Management;
using Infrastructure.ApisClients.Monitoring;
using Infrastructure.ApisClients.User;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure;

public static class DependencyInjection
{
    private const string UserServiceBaseUrlKey = "UrlsSettings:UserServiceBaseUrl";
    private const string ManagementApiBaseUrlKey = "UrlsSettings:ManagementApiBaseUrl";

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

        services.AddHttpClient<IManagementServicesClient, ManagementServicesClient>((sp, c) =>
        {
            var managementApiBaseUrl = config[ManagementApiBaseUrlKey];
            if (managementApiBaseUrl == null)
                throw new NotFoundException("ManagementApiBaseUrl is missing.");

            c.BaseAddress = new Uri(config[ManagementApiBaseUrlKey]);
        });

        services.AddHttpClient<IMonitoringServicesClient, MonitoringServicesClient>((sp, c) =>
        {
            var managementApiBaseUrl = config[ManagementApiBaseUrlKey];
            if (managementApiBaseUrl == null)
                throw new NotFoundException("ManagementApiBaseUrl is missing.");

            c.BaseAddress = new Uri(config[ManagementApiBaseUrlKey]);
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