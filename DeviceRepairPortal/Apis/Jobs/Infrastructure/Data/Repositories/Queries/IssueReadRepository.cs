using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.Queries;

internal class IssueReadRepository(ApplicationDbContext context) : IIssueReadRepository
{
    public async Task<IEnumerable<Issue>> GetIssuesAsync()
        => await context.Issues.OrderBy(i => i.Id).ToListAsync();
}
