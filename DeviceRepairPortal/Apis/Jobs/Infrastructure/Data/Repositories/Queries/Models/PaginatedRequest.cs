namespace Infrastructure.Data.Repositories.Queries.Models;

public record PaginatedRequest<T>(T Value, int PageNumber, int PageSize);