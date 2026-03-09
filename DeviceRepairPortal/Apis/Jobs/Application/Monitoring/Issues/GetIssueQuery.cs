using Application.Monitoring.Issues.Dtos;
using MediatR;

namespace Application.Monitoring.Issues;

public class GetIssueQuery() : IRequest<IEnumerable<IssueDto>>;