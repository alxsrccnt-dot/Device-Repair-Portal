namespace DeviceRepairPortal.Models;

public class PaginatedResultViewModel<T>(IEnumerable<T> data,
	int pageNumber, int pageSize, int totalCount)
{
	public IEnumerable<T> Data { get; set; } = data;
	public int PageNumber { get; set; } = pageNumber;
	public int PageSize { get; set; } = pageSize;
	public int TotalCount { get; set; } = totalCount;
	public int TotalPages { get; set; } = (int)Math.Ceiling(totalCount / (double)pageSize);

    public bool IsEmpty() => TotalCount == 0;
}