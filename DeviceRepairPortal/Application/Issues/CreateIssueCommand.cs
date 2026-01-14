using MediatR;

namespace Application.Issues;

public record CreateIssueCommand(CreateIssueRequest Request) : IRequest;