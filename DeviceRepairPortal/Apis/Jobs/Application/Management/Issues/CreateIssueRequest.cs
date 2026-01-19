namespace Application.Management.Issues;

public record CreateIssueRequest(string DevicePiece, string Description, decimal Price);