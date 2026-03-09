namespace Infrastructure.ApisClients.Management.Requests.Investigations;

public record CreateInvestigationRequest
{
    public Guid JobId { get; init; }
    public string Conclusion { get; init; }
    public string Description { get; init; }
    public IEnumerable<int> IssuesIds { get; init; }
}