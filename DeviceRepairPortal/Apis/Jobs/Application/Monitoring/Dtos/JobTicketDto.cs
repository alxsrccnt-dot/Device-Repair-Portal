using Application.Monitoring.Dtos.Common;

namespace Application.Monitoring.Dtos;

public record JobTicketDto : CreatedInformationsDto
{
    public string Description { get; init; }
    public DeviceDto Device { get; init; }
    public IEnumerable<IssueDto> Issues { get; init; }
}