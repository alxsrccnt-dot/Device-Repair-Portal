namespace Application.Common;

public class PaginatedRequest<T>
{
	public T FilterByColumn { get; set; }
	public string FilterValue { get; set; } = null;
	public int PageNumber { get; set; }
	public int PageSize { get; set; }
}
