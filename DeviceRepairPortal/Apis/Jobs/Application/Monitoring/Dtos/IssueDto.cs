namespace Application.Monitoring.Dtos;

public record IssueDto
{
    public string DevicePiece { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
}