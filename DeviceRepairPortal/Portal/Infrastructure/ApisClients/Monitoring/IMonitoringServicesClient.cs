using Infrastructure.ApisClients.Monitoring.Dto;
using Infrastructure.ApisClients.Monitoring.Requests.Common;

namespace Infrastructure.ApisClients.Monitoring;

public interface IMonitoringServicesClient
{
    Task<PaginatedResultDto<TicketDto>> GetUserTicketsAsync(PaginatedRequest request);
}