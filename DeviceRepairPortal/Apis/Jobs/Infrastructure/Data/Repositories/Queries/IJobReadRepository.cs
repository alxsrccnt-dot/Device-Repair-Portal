using Domain.Entities;
using Infrastructure.Data.Repositories.Queries.Models;

namespace Infrastructure.Data.Repositories.Queries;

public interface IJobReadRepository
{
    Task<DataWithTotalCount<Job>> GetTehnicianJobsAsync(PaginatedRequest<string> request, CancellationToken cancellationToken = default);
}