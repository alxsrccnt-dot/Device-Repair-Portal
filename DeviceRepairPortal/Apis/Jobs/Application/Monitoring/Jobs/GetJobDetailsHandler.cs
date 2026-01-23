using Application.Common.Services;
using Application.Monitoring.Dtos;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data.Repositories.Queries;
using MediatR;

namespace Application.Monitoring.Jobs;

internal class GetJobDetailsHandler(ICurrentUser currentUser, IJobReadRepository jobReadRepository, IMapper mapper) : IRequestHandler<GetJobDetailsQuery, JobDto>
{
    public async Task<JobDto> Handle(GetJobDetailsQuery request, CancellationToken cancellationToken)
    {
        var job = await jobReadRepository.GetJobDetailsAsync(request.JobId, cancellationToken);

        return mapper.Map<JobDto>(job);
    }
}