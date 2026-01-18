using Domain.Entities;
using Infrastructure.Data.Repositories.Queries.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.Queries;

internal class JobReadRepository(ApplicationDbContext context) : IJobReadRepository
{
    public async Task<DataWithTotalCount<Job>> GetTehnicianJobsAsync(JobsRequest request, CancellationToken cancellationToken = default)
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
            .AsQueryable();

        if (request.CreateBy is not null)
            query = query.Where(t => t.CreatedBy == request.CreateBy);

        if (request.InProgres is not null && request.InProgres == true)
            query = query.Where(t => t.EndDate == null);
        else if (request.InProgres is not null && request.InProgres == false)
            query = query.Where(t => t.EndDate != null);

        var jobs = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);
        var total = await query.CountAsync(cancellationToken);

        return new DataWithTotalCount<Job>(jobs, total);
    }
}