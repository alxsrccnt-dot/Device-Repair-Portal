using Domain.Entities;
using Infrastructure.Data.Repositories.Queries.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Infrastructure.Data.Repositories.Queries;

internal class TicketReadRepository(ApplicationDbContext context) : ITicketReadRepository
{
    public async Task<DataWithTotalCount<Ticket>> GetUserTicketsAsync(PaginatedRequest<string> request, CancellationToken cancellationToken = default)
    {
        var query = context.Tickets
            .Include(t => t.Job)
            .Include(t => t.Device)
            .Include(t => t.Issues)
            .AsNoTracking()
            .OrderByDescending(t => t.CreateAt)
            .Where(t => t.CreatedBy == request.Value)
            .AsQueryable();

        var tickets = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);
        var total = await query.CountAsync(cancellationToken);

        return new DataWithTotalCount<Ticket>(tickets, total);
    }
}