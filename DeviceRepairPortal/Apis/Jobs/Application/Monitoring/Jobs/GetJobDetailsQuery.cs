using Application.Monitoring.Dtos;
using MediatR;

namespace Application.Monitoring.Jobs;

public record GetJobDetailsQuery(Guid JobId) : IRequest<JobDto>;