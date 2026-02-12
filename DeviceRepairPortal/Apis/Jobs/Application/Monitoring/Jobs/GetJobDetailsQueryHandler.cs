using Application.Monitoring.Jobs.Dtos;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data.Repositories.Queries;
using MediatR;

namespace Application.Monitoring.Jobs;

internal class GetJobDetailsQueryHandler(ICurrentUser currentUser, IJobReadRepository jobReadRepository, IMapper mapper) : IRequestHandler<GetJobDetailsQuery, JobDetailsDto>
{
    public async Task<JobDetailsDto> Handle(GetJobDetailsQuery request, CancellationToken cancellationToken)
    {
        var job = await jobReadRepository.GetJobDetailsAsync(request.JobId, cancellationToken);

        return mapper.Map<JobDetailsDto>(job);
    }
}