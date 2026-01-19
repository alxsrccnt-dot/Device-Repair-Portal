namespace Infrastructure.Data.Repositories.Queries.Models;

public record TicketsRequest(string? CreateBy, bool? InProgres, int PageNumber, int PageSize)
    : PaginatedRequest(PageNumber ,PageSize);