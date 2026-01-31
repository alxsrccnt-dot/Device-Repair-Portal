using DeviceRepairPortal.Models.Issue;

namespace DeviceRepairPortal.Services;

public interface IIssueCatalog
{
    Task<IReadOnlyList<IssueViewModel>> GetAllAsync();
    Task ReloadAsync();
}