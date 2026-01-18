using Infrastructure.ApisClients.Monitoring.Dtos;
using Infrastructure.ApisClients.Monitoring.Requests.Common;

namespace Infrastructure.ApisClients.Monitoring;

public class MonitoringServicesClient(HttpClient httpClient) : BaseApiClient(httpClient), IMonitoringServicesClient
{
    public async Task<PaginatedResultDto<JobDto>> GetTehnicianJobsAsync(PaginatedRequest request)
        => await GetAsync<PaginatedResultDto<JobDto>>(GetTehnicianJobsUrl(request));

    public async Task<PaginatedResultDto<TicketDto>> GetUserTicketsAsync(PaginatedRequest request)
        => await GetAsync<PaginatedResultDto<TicketDto>>(GetUserTicketsUrl(request));

    private string GetUserTicketsUrl(PaginatedRequest request)
        => string.Format(MonitoringApiRoutesConstants.GetUserTicketEndpointRoute, request.PageNumber, request.PageSize);
    private string GetTehnicianJobsUrl(PaginatedRequest request)
        => string.Format(MonitoringApiRoutesConstants.GetTehnicianJobsEndpointRoute, request.PageNumber, request.PageSize);
}