namespace DeviceRepairPortal.Models;

public record CreatedInformationsViewModel
{
    public string CreatedBy { get; init; }
    public DateTime CreateAt { get; init; }
}
