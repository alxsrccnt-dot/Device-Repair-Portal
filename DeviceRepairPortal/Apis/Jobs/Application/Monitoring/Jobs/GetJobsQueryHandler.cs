using Application.Monitoring.Common;
using Application.Monitoring.Jobs.Dtos;
using Application.Services;
using AutoMapper;
using Infrastructure.Data.Repositories.Queries;
using Infrastructure.Data.Repositories.Queries.Models;
using MediatR;

namespace Application.Monitoring.Jobs;

internal class GetJobsQueryHandler(IJobReadRepository jobReadRepository, IMapper mapper) : IRequestHandler<GetJobsQuery, PaginatedResultDto<JobDto>>
{
    public async Task<PaginatedResultDto<JobDto>> Handle(GetJobsQuery request, CancellationToken cancellationToken)
    {
        var jobsWithTotalCount = await jobReadRepository.GetJobsAsync(
			new PaginatedRequest
			{
				PageNumber = request.PageNumber,
				PageSize = request.PageSize,
				CreateBy = request.UserEmail,
				IsActive = request.IsActive,
				StartDate = request.StartDate,
				EndDate = request.EndDate,
			}, cancellationToken);

        var jobs = mapper.Map<List<JobDto>>(jobsWithTotalCount.Items);

        return new PaginatedResultDto<JobDto>(jobs, request.PageNumber, request.PageSize, jobsWithTotalCount.TotalCount);
    }
}