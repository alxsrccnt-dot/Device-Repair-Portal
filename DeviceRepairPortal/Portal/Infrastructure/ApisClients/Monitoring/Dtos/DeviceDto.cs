namespace Infrastructure.ApisClients.Monitoring.Dtos;

public record DeviceDto
{
    public string Brand { get; init; }
    public string Model { get; init; }
    public string SerialNumber { get; init; }
}