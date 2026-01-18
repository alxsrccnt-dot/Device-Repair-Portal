using Application.Monitoring.Dtos.Common;
using Domain.Enums;

namespace Application.Monitoring.Dtos;

public class PhaseDto : CreatedInformationsDto
{
    public State State { get; init; }
}