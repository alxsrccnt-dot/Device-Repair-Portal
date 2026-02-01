using Application.Monitoring.Common;
using Application.Monitoring.Issues.Dtos;
using Application.Monitoring.Tickets.Dtos;

namespace Application.Monitoring.Jobs.Dtos;

public class JobDetailsTicketDto : CreatedInformationsDto
{
    public string Description { get; init; }
    public DeviceDto Device { get; init; }
    public IEnumerable<IssueDto> UserDeclaredIssues { get; init; }
}