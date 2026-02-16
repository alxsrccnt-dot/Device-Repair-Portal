using Domain.Entities;
using Infrastructure.Data.Repositories.Queries.Models;

namespace Infrastructure.Data.Repositories.Queries;

public interface IJobReadRepository
{
    Task<Job> GetJobDetailsAsync(Guid id, CancellationToken cancellationToken = default);
    Task<DataWithTotalCount<Job>> GetJobsAsync(PaginatedRequest request, CancellationToken cancellationToken = default);
}