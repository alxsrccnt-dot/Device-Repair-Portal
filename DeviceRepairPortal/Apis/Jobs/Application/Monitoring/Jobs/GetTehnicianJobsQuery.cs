using Application.Monitoring.Dtos;
using MediatR;

namespace Application.Monitoring.Jobs;

public record GetTehnicianJobsQuery(int PageNumber, int PageSize) : IRequest<PaginatedResultDto<JobDto>>;