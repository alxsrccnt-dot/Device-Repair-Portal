using DeviceRepairPortal.Models.Issue;

namespace Infrastructure.Services;

public interface IIssueCatalog
{
    Task<IReadOnlyList<IssueViewModel>> GetAllAsync();
    Task ReloadAsync();
}