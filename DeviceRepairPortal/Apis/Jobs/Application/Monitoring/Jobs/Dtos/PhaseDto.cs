using Application.Monitoring.Common;
using Domain.Enums;

namespace Application.Monitoring.Jobs.Dtos;

public class PhaseDto : CreatedInformationsDto
{
    public State State { get; init; }
}