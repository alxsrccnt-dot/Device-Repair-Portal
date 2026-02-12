using Application.Monitoring.Common;
using Application.Monitoring.Jobs.Dtos;
using Application.Services;
using AutoMapper;
using Infrastructure.Data.Repositories.Queries;
using Infrastructure.Data.Repositories.Queries.Models;
using MediatR;

namespace Application.Monitoring.Jobs;

internal class GetJobsQueryHandler(ICurrentUser currentUser, IJobReadRepository jobReadRepository, IMapper mapper) : IRequestHandler<GetJobsQuery, PaginatedResultDto<JobDto>>
{
    public async Task<PaginatedResultDto<JobDto>> Handle(GetJobsQuery request, CancellationToken cancellationToken)
    {
        var jobsWithTotalCount = await jobReadRepository.GetTehnicianJobsAsync(
            new JobsRequest(currentUser.Email!, null, request.PageNumber, request.PageSize), cancellationToken);

        var jobs = mapper.Map<List<JobDto>>(jobsWithTotalCount.Items);

        return new PaginatedResultDto<JobDto>(jobs, request.PageNumber, request.PageSize, jobsWithTotalCount.TotalCount);
    }
}