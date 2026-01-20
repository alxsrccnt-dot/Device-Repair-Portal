using Infrastructure.ApisClients.Common;
using Infrastructure.ApisClients.Monitoring.Dtos.Common;

namespace Infrastructure.ApisClients.Monitoring.Dtos;

public record PhaseDto : CreatedInformationsDto
{
    public State State { get; init; }
}