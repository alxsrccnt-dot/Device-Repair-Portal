using Domain.Entities;
using Infrastructure.Data.Repositories.Queries.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.Queries;

internal class TicketReadRepository(ApplicationDbContext context) : ITicketReadRepository
{
    public async Task<DataWithTotalCount<Ticket>> GetTicketsAsync(PaginatedRequest request, CancellationToken cancellationToken = default)
    {
        var query = context.Tickets
            .Include(t => t.Job)
			.Include(t => t.Device)
            .Include(t => t.Issues)
            .AsNoTracking()
            .OrderByDescending(t => t.CreateAt)
            .AsQueryable();

        if (request.CreateBy is not null)
            query = query.Where(t => t.CreatedBy == request.CreateBy);

		if (request.IsActive is not null && request.IsActive == true)
            query = query.Where(t => t.Job != null);
        else if (request.IsActive is not null && request.IsActive == false)
            query = query.Where(t => t.Job == null);

		if (request.StartDate is not null && request.EndDate is null)
			query = query.Where(t => t.CreateAt.Date == request.StartDate.Value.Date);

		if (request.StartDate is not null && request.EndDate is not null)
			query = query.Where(t => t.CreateAt.Date == request.StartDate.Value.Date);

		var tickets = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);
        var total = await query.CountAsync(cancellationToken);

        return new DataWithTotalCount<Ticket>(tickets, total);
    }
}