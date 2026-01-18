namespace Infrastructure.ApisClients.Monitoring.Requests.Common;

public record PaginatedRequest(int PageNumber, int PageSize);