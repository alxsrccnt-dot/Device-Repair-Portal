namespace Infrastructure.Data.Repositories.Queries.Models;

public record JobsRequest(string? CreateBy, bool? InProgres, int PageNumber, int PageSize)
    : PaginatedRequest(PageNumber, PageSize);