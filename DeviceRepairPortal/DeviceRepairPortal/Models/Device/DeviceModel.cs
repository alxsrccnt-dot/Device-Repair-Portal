namespace DeviceRepairPortal.Models.Device;

public record DeviceModel
{
    public string Brand { get; init; }
    public string Model { get; init; }
    public string SerialNumber { get; init; }
}