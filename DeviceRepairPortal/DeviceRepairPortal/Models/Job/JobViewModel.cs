using Infrastructure.ApisClients.Monitoring.Dtos;

namespace DeviceRepairPortal.Models.Job;

public class JobViewModel
{
    public Guid Id { get; set; }
    public DateTime? EndDate { get; init; }
    public required JobDetailsTicketDto Ticket { get; init; }
    public string? InvestigationConclusion { get; init; }
    public decimal? BillingInformationAmount { get; init; }
    public required string CurrentPhase { get; set; }
    public required DateTime CurrentPhasesStartedAt { get; set; }
}