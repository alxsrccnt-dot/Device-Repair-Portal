namespace Application.Monitoring.Jobs.Dtos;

public class JobDto
{
    public Guid Id { get; set; }
    public DateTime? EndDate { get; init; }
    public required JobTicketDto Ticket { get; init; }
    public string? InvestigationConclusion { get; init; }
    public decimal? BillingInformationAmount { get; init; }
    public required string CurrentPhase { get; set; }
    public required DateTime CurrentPhasesStartedAt { get; set; }
}