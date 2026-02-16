using Domain.Entities;
using Infrastructure.Data.Repositories.Queries.Models;

namespace Infrastructure.Data.Repositories.Queries;

public interface ITicketReadRepository
{
    Task<DataWithTotalCount<Ticket>> GetTicketsAsync(PaginatedRequest request, CancellationToken cancellationToken = default);
}