using Infrastructure.ApisClients.Monitoring.Requests.Common;

namespace Infrastructure.ApisClients.Monitoring.Requests;

public record GetTicketsRequest(string? UserEmail, bool? IsActive, int PageNumber, int PageSize) : PaginatedRequest(PageNumber,PageSize);