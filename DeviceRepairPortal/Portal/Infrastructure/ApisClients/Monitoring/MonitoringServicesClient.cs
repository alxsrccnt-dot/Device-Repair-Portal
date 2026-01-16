using Infrastructure.ApisClients.Monitoring.Dto;
using Infrastructure.ApisClients.Monitoring.Requests.Common;

namespace Infrastructure.ApisClients.Monitoring;

public class MonitoringServicesClient(HttpClient httpClient) : BaseApiClient(httpClient), IMonitoringServicesClient
{
    public Task<PaginatedResultDto<TicketDto>> GetUserTicketsAsync(PaginatedRequest request)
    {
        throw new NotImplementedException();
    }
}