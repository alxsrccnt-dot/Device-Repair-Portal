using Domain.Entities;

namespace Infrastructure.Data.Repositories.Queries;

public interface IReadIssuesRepositories
{
    Task<ICollection<Issue>> GetIssuesByIds(IEnumerable<int> ids);
    Task<Issue> GetByDevicePieceAsync(string devicePiece);
}