using Infrastructure.ApisClients.Monitoring.Dto;
using Infrastructure.ApisClients.Monitoring.Requests.Common;

namespace Infrastructure.ApisClients.Monitoring;

public class MonitoringServicesClient(HttpClient httpClient) : BaseApiClient(httpClient), IMonitoringServicesClient
{
    public async Task<PaginatedResultDto<TicketDto>> GetUserTicketsAsync(PaginatedRequest request)
        => await GetAsync<PaginatedResultDto<TicketDto>>(GetUserTicketsUrl(request));

    private string GetUserTicketsUrl(PaginatedRequest request)
        => string.Format(MonitoringApiRoutesConstants.GetUserTicketEndpointRoute, request.PageNumber, request.PageSize);
}