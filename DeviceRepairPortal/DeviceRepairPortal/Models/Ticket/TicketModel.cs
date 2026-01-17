using DeviceRepairPortal.Models.Device;
using DeviceRepairPortal.Models.Issue;
using Infrastructure.ApisClients.Monitoring.Dtos;

namespace DeviceRepairPortal.Models.Ticket;

public record TicketModel : BaseModel<Guid>
{
    public string Description { get; init; }
    public DateTime? JobStartedAt { get; init; }
    public string? TehnicianUsername { get; init; }
    public Guid? JobId { get; init; }
    public DeviceModel Device { get; init; }
    public IEnumerable<IssueModel> Issues { get; init; }
    public DateTime CreatedAt { get; init; }
}