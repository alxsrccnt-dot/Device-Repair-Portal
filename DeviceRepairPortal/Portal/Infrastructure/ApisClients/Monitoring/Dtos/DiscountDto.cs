namespace Infrastructure.ApisClients.Monitoring.Dtos;

public record DiscountDto
{
    public string Code { get; init; }
    public int Value { get; init; }
    public bool IsPercentage { get; init; }
}