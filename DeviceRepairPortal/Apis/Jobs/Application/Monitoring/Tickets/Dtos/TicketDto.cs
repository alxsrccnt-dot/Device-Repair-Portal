using Application.Monitoring.Common;
using Application.Monitoring.Issues.Dtos;

namespace Application.Monitoring.Tickets.Dtos;

public class TicketDto : BaseDto<Guid>
{
    public DateTime CreatedAt { get; init; }
    public required string Description { get; init; }
    public required DeviceDto Device { get; init; }
    public IEnumerable<IssueDto>? UserDeclaredIssues { get; init; }
    public Guid? JobId { get; init; }
    public DateTime? JobStartedAt { get; init; }
    public string? TehnicianUsername { get; init; }
}