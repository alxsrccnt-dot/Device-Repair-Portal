using Infrastructure.ApisClients.Monitoring.Dtos;
using Infrastructure.ApisClients.Monitoring.Requests.Common;

namespace Infrastructure.ApisClients.Monitoring;

public interface IMonitoringServicesClient
{
    Task<PaginatedResultDto<TicketDto>> GetUserTicketsAsync(PaginatedRequest request);
}