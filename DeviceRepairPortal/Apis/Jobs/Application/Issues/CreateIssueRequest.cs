namespace Application.Issues;

public record CreateIssueRequest(string DevicePiece, string Description, decimal Price);