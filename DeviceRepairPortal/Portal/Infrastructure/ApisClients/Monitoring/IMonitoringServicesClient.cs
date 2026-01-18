using Infrastructure.ApisClients.Monitoring.Dtos;
using Infrastructure.ApisClients.Monitoring.Requests;
using Infrastructure.ApisClients.Monitoring.Requests.Common;

namespace Infrastructure.ApisClients.Monitoring;

public interface IMonitoringServicesClient
{
    Task<PaginatedResultDto<TicketDto>> GetUserTicketsAsync(PaginatedRequest request);
    Task<PaginatedResultDto<TicketDto>> GetTicketsAsync(GetTicketsRequest request);
    Task<PaginatedResultDto<JobDto>> GetTehnicianJobsAsync(PaginatedRequest request);
    Task<IEnumerable<IssueDto>> GetIssuesAsync();
}