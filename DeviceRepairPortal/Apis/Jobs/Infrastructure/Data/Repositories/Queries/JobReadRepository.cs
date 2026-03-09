using Azure.Core;
using Domain.Entities;
using Infrastructure.Data.Repositories.Queries.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.Queries;

internal class JobReadRepository(ApplicationDbContext context) : IJobReadRepository
{
    public async Task<Job> GetJobDetailsAsync(Guid id, CancellationToken cancellationToken = default)
        => await context.Jobs
            .Include(j => j.Ticket)
            .ThenInclude(t => t.Device)
			.Include(j => j.Ticket)
			.ThenInclude(t => t.Issues)
			.Include(j => j.Investigation )
            .ThenInclude(i => i.Issues)
            .Include(j => j.BillingInformation)
            .ThenInclude(bi => bi.Discount)
            .Include(j => j.Comments)
            .Include(j => j.Phases)
            .AsNoTracking()
            .FirstAsync(j => j.Id == id, cancellationToken);

    public async Task<DataWithTotalCount<Job>> GetJobsAsync(PaginatedRequest request, CancellationToken cancellationToken = default)
    {
        var query = context.Jobs
            .Include(j => j.Ticket)
            .ThenInclude(t => t.Device)
            .Include(j => j.Investigation)
            .Include(j => j.BillingInformation)
			.Include(j => j.Phases)
            .AsNoTracking()
            .OrderByDescending(t => t.CreateAt)
            .AsQueryable();

		if (request.CreateBy is not null)
			query = query.Where(t => t.CreatedBy == request.CreateBy);

		if (request.IsActive is not null && request.IsActive == true)
			query = query.Where(t => t.EndDate == null);
		else if (request.IsActive is not null && request.IsActive == false)
			query = query.Where(t => t.EndDate != null);

		if (request.StartDate is not null && request.EndDate is null)
			query = query.Where(t => t.CreateAt.Date == request.StartDate.Value.Date);

		if (request.StartDate is not null && request.EndDate is not null)
			query = query.Where(t => t.CreateAt.Date == request.StartDate.Value.Date);

		var jobs = await query
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);
        var total = await query.CountAsync(cancellationToken);

        return new DataWithTotalCount<Job>(jobs, total);
    }
}