using Infrastructure.ApisClients.Monitoring.Dtos;
using Infrastructure.ApisClients.Monitoring.Requests;
using Infrastructure.ApisClients.Monitoring.Requests.Common;

namespace Infrastructure.ApisClients.Monitoring;

public class MonitoringServicesClient(HttpClient httpClient) : BaseApiClient(httpClient), IMonitoringServicesClient
{
    public async Task<PaginatedResultDto<JobDto>> GetTehnicianJobsAsync(PaginatedRequest request)
        => await GetAsync<PaginatedResultDto<JobDto>>(GetTehnicianJobsUrl(request));

    public async Task<PaginatedResultDto<TicketDto>> GetUserTicketsAsync(PaginatedRequest request)
        => await GetAsync<PaginatedResultDto<TicketDto>>(GetUserTicketsUrl(request));

    public async Task<PaginatedResultDto<TicketDto>> GetTicketsAsync(GetTicketsRequest request)
        => await GetAsync<PaginatedResultDto<TicketDto>>(GetTicketsUrl(request));

    public async Task<IEnumerable<IssueDto>> GetIssuesAsync()
        => await GetAsync<IEnumerable<IssueDto>>(MonitoringApiRoutesConstants.GetIssuesEndpointRoute);

    private string GetUserTicketsUrl(PaginatedRequest request)
        => string.Format(MonitoringApiRoutesConstants.GetUserTicketEndpointRoute, request.PageNumber, request.PageSize);

    private string GetTicketsUrl(GetTicketsRequest request)
        => string.Format(MonitoringApiRoutesConstants.GetUserTicketEndpointRoute, request.PageNumber, request.PageSize);

    private string GetTehnicianJobsUrl(PaginatedRequest request)
        => string.Format(MonitoringApiRoutesConstants.GetTehnicianJobsEndpointRoute, request.PageNumber, request.PageSize);
}