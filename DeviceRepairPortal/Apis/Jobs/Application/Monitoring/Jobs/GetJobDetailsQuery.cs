using Application.Monitoring.Jobs.Dtos;
using MediatR;

namespace Application.Monitoring.Jobs;

public record GetJobDetailsQuery(Guid JobId) : IRequest<JobDetailsDto>;