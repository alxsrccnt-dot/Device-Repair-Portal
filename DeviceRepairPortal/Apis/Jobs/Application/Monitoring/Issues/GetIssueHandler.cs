using Application.Monitoring.Dtos;
using AutoMapper;
using Infrastructure.Data.Repositories.Queries;
using MediatR;

namespace Application.Monitoring.Issues;

public class GetIssueHandler(IReadIssuesRepositories readIssuesRepositories, IMapper mapper) : IRequestHandler<GetIssueQuery, IEnumerable<IssueDto>>
{
    public async Task<IEnumerable<IssueDto>> Handle(GetIssueQuery request, CancellationToken cancellationToken)
        => mapper.Map<IEnumerable<IssueDto>>(await readIssuesRepositories.GetIssuesAsync());
}