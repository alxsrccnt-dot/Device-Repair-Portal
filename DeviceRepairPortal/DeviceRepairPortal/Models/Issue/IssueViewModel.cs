namespace DeviceRepairPortal.Models.Issue;

public record IssueViewModel/* : BaseViewModel<int>*/
{
    public int Id { get; set; }
    public string DevicePiece { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
}