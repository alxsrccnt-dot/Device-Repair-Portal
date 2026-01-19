using Domain.Entities;

namespace Infrastructure.Data.Repositories.Queries;

public interface IReadIssuesRepositories
{
    Task<ICollection<Issue>> GetIssuesByIds(IEnumerable<int> ids, CancellationToken cancellationToken = default);
    Task<Issue?> GetByDevicePieceAsync(string devicePiece, CancellationToken cancellationToken = default);
    Task<IEnumerable<Issue>> GetIssuesAsync(CancellationToken cancellationToken = default);
}