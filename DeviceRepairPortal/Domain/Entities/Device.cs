using Domain.Entities.Base;

namespace Domain.Entities;

public class Device(string brand, string model, string serialNumber) : Entity<int>
{
    public string Brand { get; set; } = brand;
    public string Model { get; set; } = model;
    public string SerialNumber { get; set; } = serialNumber;

    public Guid JobId { get; set; }
    public Job Job { get; set; } = null!;
}