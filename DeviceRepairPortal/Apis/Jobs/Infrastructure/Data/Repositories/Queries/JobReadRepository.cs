using Domain.Entities;
using Infrastructure.Data.Repositories.Queries.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.Queries;

internal class JobReadRepository(ApplicationDbContext context) : IJobReadRepository
{
    public async Task<DataWithTotalCount<Job>> GetTehnicianJobsAsync(PaginatedRequest<string> request, CancellationToken cancellationToken = default)
    {
        var query = context.Jobs
            .Include(j => j.Ticket)
            .ThenInclude(t => t.Device)
            .Include(j => j.Investigation)
            .ThenInclude(i => i.Issues)
            .Include(j => j.BillingInformation)
            .ThenInclude(bi => bi.Discount)
            .Include(j => j.Comments)
            .Include(j => j.Phases)
            .AsNoTracking()
            .OrderByDescending(t => t.CreateAt)
            .Where(t => t.CreatedBy == request.Value)
            .AsQueryable();

        var jobs = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);
        var total = await query.CountAsync(cancellationToken);

        return new DataWithTotalCount<Job>(jobs, total);
    }
}