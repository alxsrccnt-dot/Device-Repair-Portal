namespace Infrastructure.ApisClients.Monitoring.Dtos;

public class PaginatedResultModel<T>(IEnumerable<T> data,
	int pageNumber, int pageSize, int totalCount)
{
	public IEnumerable<T> Data { get; set; } = data;
	public int PageNumber { get; set; } = pageNumber;
	public int PageSize { get; set; } = pageSize;
	public int TotalCount { get; set; } = totalCount;
	public int TotalPages { get; set; } = totalCount / pageSize;

	public bool IsEmpty() => TotalCount == 0;
}