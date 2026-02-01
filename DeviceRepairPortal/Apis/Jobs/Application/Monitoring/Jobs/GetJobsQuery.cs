using Application.Monitoring.Common;
using Application.Monitoring.Jobs.Dtos;
using MediatR;

namespace Application.Monitoring.Jobs;

public record GetJobsQuery(int PageNumber, int PageSize) : IRequest<PaginatedResultDto<JobDto>>;