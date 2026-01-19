using Infrastructure.ApisClients.Monitoring.Dtos.Common;

namespace Infrastructure.ApisClients.Monitoring.Dtos;

public record TicketDto : BaseDto<Guid>
{
    public string Description { get; init; }
    public DateTime? JobStartedAt { get; init; }
    public string? TehnicianUsername { get; init; }
    public Guid? JobId { get; init; }
    public DeviceDto Device { get; init; }
    public IEnumerable<IssueDto> Issues { get; init; }
    public DateTime CreatedAt { get; init; }
}