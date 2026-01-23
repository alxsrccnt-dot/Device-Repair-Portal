using AutoMapper;
using DeviceRepairPortal.Models.Issue;
using Infrastructure.ApisClients.Monitoring;
using Infrastructure.Services;

namespace DeviceRepairPortal.Services;

public class IssueCatalog(IServiceScopeFactory scopeFactory) : IIssueCatalog
{
    private IReadOnlyList<IssueViewModel>? _cache;

    public async Task<IReadOnlyList<IssueViewModel>> GetAllAsync()
    {
        if (_cache != null)
            return _cache;

        await ReloadAsync();
        return _cache!;
    }

    public async Task ReloadAsync()
    {
        using var scope = scopeFactory.CreateScope();
        var monitoringServicesClient = scope.ServiceProvider.GetRequiredService<IMonitoringServicesClient>();
        var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
        var issues = await monitoringServicesClient.GetIssuesAsync();

        _cache = mapper.Map<IReadOnlyList<IssueViewModel>>(issues);
    }
}