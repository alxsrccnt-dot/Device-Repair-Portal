using Infrastructure.ApisClients.Monitoring.Dtos.Enums;

namespace DeviceRepairPortal.Models.Phase;

public record PhaseViewModel : CreatedInformationsViewModel
{
    public State State { get; init; }
}
