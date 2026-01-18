namespace Infrastructure.ApisClients.Management.Requests.Tickets;

public record CreateTicketRequest()
{
    public string Description { get; init; }
    public string Brand { get; init; }
    public string Model { get; init; }
    public string SerialNumber { get; init; }
    public IEnumerable<int> IssuesIds { get; init; }
}