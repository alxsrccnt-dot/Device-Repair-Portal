namespace Infrastructure.ApisClients.Monitoring.Dtos;

public class JobDto
{
    public Guid Id { get; set; }
    public DateTime? EndDate { get; init; }
    public required JobDetailsTicketDto Ticket { get; init; }
    public string? InvestigationConclusion { get; init; }
    public decimal? BillingInformationAmount { get; init; }
    public required string CurrentPhase { get; set; }
    public required DateTime CurrentPhasesStartedAt { get; set; }
}