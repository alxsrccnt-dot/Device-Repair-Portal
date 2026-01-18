using Domain.Entities;
using Infrastructure.Data.Repositories.Queries.Models;

namespace Infrastructure.Data.Repositories.Queries;

public interface ITicketReadRepository
{
    Task<DataWithTotalCount<Ticket>> GetUserTicketsAsync(TicketsRequest request, CancellationToken cancellationToken = default);
}