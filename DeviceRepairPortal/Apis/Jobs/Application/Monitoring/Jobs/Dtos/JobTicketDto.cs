using Application.Monitoring.Common;
using Application.Monitoring.Tickets.Dtos;

namespace Application.Monitoring.Jobs.Dtos;

public class JobTicketDto : CreatedInformationsDto
{
    public required string Description { get; init; }
    public required DeviceDto Device { get; init; }
}