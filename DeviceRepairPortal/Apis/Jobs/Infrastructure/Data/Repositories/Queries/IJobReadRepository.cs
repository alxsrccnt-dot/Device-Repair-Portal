using Domain.Entities;
using Infrastructure.Data.Repositories.Queries.Models;

namespace Infrastructure.Data.Repositories.Queries;

public interface IJobReadRepository
{
    Task<Job> GetJobDetailsAsync(Guid id, CancellationToken cancellationToken = default);
    Task<DataWithTotalCount<Job>> GetTehnicianJobsAsync(JobsRequest request, CancellationToken cancellationToken = default);
}