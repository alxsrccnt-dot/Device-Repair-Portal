using Domain.Entities;

namespace Infrastructure.Data.Repositories.Queries;

public interface IIssueReadRepository
{
    Task<IEnumerable<Issue>> GetIssuesAsync();
}