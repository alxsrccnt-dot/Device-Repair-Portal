namespace DeviceRepairPortal.Models.Issue;

public record IssueViewModel
{
    public string DevicePiece { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
}