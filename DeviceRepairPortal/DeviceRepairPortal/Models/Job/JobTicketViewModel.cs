using DeviceRepairPortal.Models.Device;
using Infrastructure.ApisClients.Monitoring.Dtos;

namespace DeviceRepairPortal.Models.Job;

public record JobTicketViewModel : CreatedInformationsViewModel
{
    public string Description { get; init; }
    public DeviceViewModel Device { get; init; }
    public IEnumerable<IssueDto> Issues { get; init; }
}
