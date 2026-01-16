namespace Application.Management.Tikets;

public record CreateTicketRequest(string Description, string Brand, string Model, string SerialNumber, IEnumerable<int> IssuesIds);