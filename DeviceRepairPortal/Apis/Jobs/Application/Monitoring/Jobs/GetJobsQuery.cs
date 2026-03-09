using Application.Monitoring.Common;
using Application.Monitoring.Jobs.Dtos;
using MediatR;

namespace Application.Monitoring.Jobs;

public record GetJobsQuery(int PageNumber, int PageSize,
	string? UserEmail = null, bool? IsActive = null,
	DateTime? StartDate = null, DateTime? EndDate = null) : IRequest<PaginatedResultDto<JobDto>>;