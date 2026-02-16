namespace Infrastructure.Data.Repositories.Queries.Models;

public record PaginatedRequest()
{
	public int PageNumber { get; init; }
	public int PageSize { get; init; } = 10;
	public string? CreateBy { get; init; } = null;
	public bool? IsActive { get; init; } = null;
	public DateTime? StartDate { get; init; } = null;
	public DateTime? EndDate { get; init; } = null;
}