namespace Application.Monitoring.Common;

public class DiscountDto
{
    public required string Code { get; init; }
    public int Value { get; init; }
    public bool IsPercentage { get; init; }
}