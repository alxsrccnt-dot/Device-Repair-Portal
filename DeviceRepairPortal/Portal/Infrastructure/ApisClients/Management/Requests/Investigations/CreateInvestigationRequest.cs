namespace Infrastructure.ApisClients.Management.Requests.Investigations;

public record CreateInvestigationRequest(Guid JobId, string Conclusion, string Description, IEnumerable<int> IssuesIds);