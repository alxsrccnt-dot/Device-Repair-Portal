namespace DeviceRepairPortal.Models.Investigation;

public class CreateInvestigationInputModel
{
    public Guid JobId { get; set; }
    public string Conclusion { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<int> IssueIds { get; set; } = [];
}
