using Infrastructure.ApisClients.Management;
using Infrastructure.ApisClients.Monitoring;
using Infrastructure.ApisClients.User;
using Infrastructure.Exceptions;
using Infrastructure.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http.Headers;

namespace Infrastructure;

public static class DependencyInjection
{
    private const string UserServiceBaseUrlKey = "UrlsSettings:UserServiceBaseUrl";
    private const string ManagementApiBaseUrlKey = "UrlsSettings:ManagementApiBaseUrl";
    private const string MonitoringApiBaseUrlKey = "UrlsSettings:MonitoringApiBaseUrl";

    public static IServiceCollection AddWebsiteInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddCustomAuthentication();
        services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<BearerTokenHandler>();
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
        })
        .AddHttpMessageHandler<BearerTokenHandler>();

        services.AddHttpClient<IManagementServicesClient, ManagementServicesClient>((sp, c) =>
        {
            var httpContext = sp.GetRequiredService<HttpContext>();
            var token = httpContext.Request.Cookies["access_token"];
            var managementApiBaseUrl = config[ManagementApiBaseUrlKey];
            if (managementApiBaseUrl == null)
                throw new NotFoundException("ManagementApiBaseUrl is missing.");

            c.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
            c.BaseAddress = new Uri(config[ManagementApiBaseUrlKey]);
        })
        .AddHttpMessageHandler<BearerTokenHandler>();

        services.AddHttpClient<IMonitoringServicesClient, MonitoringServicesClient>((sp, c) =>
        {
            var managementApiBaseUrl = config[MonitoringApiBaseUrlKey];
            if (managementApiBaseUrl == null)
                throw new NotFoundException("MonitoringApiBaseUrl is missing.");

            c.BaseAddress = new Uri(config[MonitoringApiBaseUrlKey]);
        })
        .AddHttpMessageHandler<BearerTokenHandler>();
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