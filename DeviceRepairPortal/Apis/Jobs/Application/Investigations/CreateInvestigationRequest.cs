namespace Application.Investigations;

public record CreateInvestigationRequest(Guid JobId, string Conclusion, string Description, IEnumerable<int> IssuesIds);