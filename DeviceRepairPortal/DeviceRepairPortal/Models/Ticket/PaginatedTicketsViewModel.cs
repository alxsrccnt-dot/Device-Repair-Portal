namespace DeviceRepairPortal.Models.Ticket;

public class PaginatedTicketsViewModel(IEnumerable<TicketViewModel> data, int pageNumber, int pageSize, int totalCount)
    : PaginatedViewModel<TicketViewModel>(data, pageNumber, pageSize, totalCount)
{
    public string? UserEmail { get; set; }
    public bool? IsActive { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}