namespace Infrastructure.ApisClients.Management.Requests.Tickets;

public record CreateTicketRequest(string Description, string Brand, string Model, string SerialNumber, IEnumerable<int> IssuesIds);