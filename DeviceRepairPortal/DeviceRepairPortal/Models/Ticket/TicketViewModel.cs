using DeviceRepairPortal.Models.Device;
using DeviceRepairPortal.Models.Issue;

namespace DeviceRepairPortal.Models.Ticket;

public record TicketViewModel : BaseViewModel<Guid>
{
    public string Description { get; init; }
    public DateTime? JobStartedAt { get; init; }
    public string? TehnicianUsername { get; init; }
    public Guid? JobId { get; init; }
    public DeviceViewModel Device { get; init; }
    public IEnumerable<IssueViewModel> Issues { get; init; }
    public DateTime CreatedAt { get; init; }
}