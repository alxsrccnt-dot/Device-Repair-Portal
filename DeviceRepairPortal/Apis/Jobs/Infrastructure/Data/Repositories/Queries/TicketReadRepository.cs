using Domain.Entities;
using Infrastructure.Data.Repositories.Queries.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.Queries;

internal class TicketReadRepository(ApplicationDbContext context) : ITicketReadRepository
{
    public async Task<DataWithTotalCount<Ticket>> GetUserTicketsAsync(TicketsRequest request, CancellationToken cancellationToken = default)
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

        if (request.InProgres is not null && request.InProgres == true)
            query = query.Where(t => t.Job != null);
        else if (request.InProgres is not null && request.InProgres == false)
            query = query.Where(t => t.Job == null);


        var tickets = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);
        var total = await query.CountAsync(cancellationToken);

        return new DataWithTotalCount<Ticket>(tickets, total);
    }
}