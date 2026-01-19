namespace Infrastructure.ApisClients.Management.Requests.Jobs;

public record CreateJobRequest
{
    public Guid TicketId { get; init; }
    public string Comment { get; init; }
}