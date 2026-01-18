using Infrastructure.Data.Repositories.Queries.Models;

namespace Application.Monitoring.Tickets;

public record GetTicketsRequest(string UserEmail, bool IsActive, int PageNumber, int PageSize) : PaginatedRequest(PageNumber,PageSize);