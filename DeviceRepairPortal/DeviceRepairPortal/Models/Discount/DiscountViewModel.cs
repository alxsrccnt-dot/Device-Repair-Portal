namespace DeviceRepairPortal.Models.Discount;

public record DiscountViewModel
{
    public string Code { get; init; }
    public int Value { get; init; }
    public bool IsPercentage { get; init; }
}