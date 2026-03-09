namespace DeviceRepairPortal.Models.Investigation;

public class CreateInvestigationInputModel
{
    public Guid JobId { get; set; }
    public string Conclusion { get; set; }
    public string Description { get; set; }
    public List<int> IssueIds { get; set; } = [];
}
