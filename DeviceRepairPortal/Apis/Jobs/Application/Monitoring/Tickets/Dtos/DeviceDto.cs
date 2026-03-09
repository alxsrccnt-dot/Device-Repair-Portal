namespace Application.Monitoring.Tickets.Dtos;

public class DeviceDto
{
    public required string Brand { get; init; }
    public required string Model { get; init; }
    public required string SerialNumber { get; init; }
}