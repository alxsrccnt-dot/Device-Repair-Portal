using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.Queries;

internal class ReadIssuesRepositories(ApplicationDbContext context) : IReadIssuesRepositories
{
    public async Task<ICollection<Issue>> GetIssuesByIds(IEnumerable<int> ids, CancellationToken cancellationToken = default)
        => await context.Issues.Where(i => ids.Contains(i.Id)).ToListAsync(cancellationToken);

    public async Task<Issue?> GetByDevicePieceAsync(string devicePiece, CancellationToken cancellationToken = default)
        => await context.Issues.SingleOrDefaultAsync(i => i.DevicePiece == devicePiece, cancellationToken);

    public async Task<IEnumerable<Issue>> GetIssuesAsync(CancellationToken cancellationToken = default)
        => await context.Issues.OrderBy(i => i.Id).ToListAsync(cancellationToken);
}