using Infrastructure.ApisClients.Monitoring.Dtos.Common;
using Infrastructure.ApisClients.Monitoring.Dtos.Enums;

namespace Infrastructure.ApisClients.Monitoring.Dtos;

public record PhaseDto : CreatedInformationsDto
{
    public State State { get; init; }
}