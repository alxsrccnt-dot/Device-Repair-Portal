using MediatR;

namespace Application.Management.Issues;

public record CreateIssueCommand(CreateIssueRequest Request) : IRequest;