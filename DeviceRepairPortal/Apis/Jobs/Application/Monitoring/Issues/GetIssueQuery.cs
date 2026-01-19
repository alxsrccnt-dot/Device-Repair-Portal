using Application.Monitoring.Dtos;
using MediatR;

namespace Application.Monitoring.Issues;

public class GetIssueQuery() : IRequest<IEnumerable<IssueDto>>;