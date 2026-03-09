using Infrastructure.ApisClients.Common;

namespace DeviceRepairPortal.Models.Phase;

public record PhaseViewModel : CreatedInformationsViewModel
{
    public State State { get; init; }
}