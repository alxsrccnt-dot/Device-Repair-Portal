using Infrastructure.ApisClients.Monitoring.Dtos.Common;

namespace Infrastructure.ApisClients.Monitoring.Dtos;

public record JobDetailsTicketDto : CreatedInformationsDto
{
    public string Description { get; init; }
    public DeviceDto Device { get; init; }
    public IEnumerable<IssueDto> UserDeclaredIssues { get; init; }
}