using Domain.Entities.Base;

namespace Domain.Entities;

public class Device(string brand, string model, string serialNumber) : BaseEntity<int>
{
    public string Brand { get; set; } = brand;
    public string Model { get; set; } = model;
    public string SerialNumber { get; set; } = serialNumber;

    public Ticket Ticket { get; set; } = null!;
}