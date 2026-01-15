using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.Queries;

internal class ReadIssuesRepositories(ApplicationDbContext context) : IReadIssuesRepositories
{
    public async Task<ICollection<Issue>> GetIssuesByIds(IEnumerable<int> ids)
        => await context.Issues.Where(i => ids.Contains(i.Id)).ToListAsync();

    public async Task<Issue> GetByDevicePieceAsync(string devicePiece)
        => await context.Issues.SingleAsync(i => i.DevicePiece == devicePiece);
}