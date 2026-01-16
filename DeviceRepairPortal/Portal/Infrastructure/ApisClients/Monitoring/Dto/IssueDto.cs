namespace Infrastructure.ApisClients.Monitoring.Dto;

public record IssueDto
{
    public string DevicePiece { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
}