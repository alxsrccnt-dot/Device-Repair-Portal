using Application.Monitoring.Common;
using Application.Monitoring.Tickets.Dtos;
using Application.Services;
using AutoMapper;
using Infrastructure.Data.Repositories.Queries;
using Infrastructure.Data.Repositories.Queries.Models;

namespace Application.Monitoring.Tickets;

public class GetTicketsBaseHandler(ICurrentUser currentUser, ITicketReadRepository ticketReadRepository, IMapper mapper)
{
    public async Task<PaginatedResultDto<TicketDto>> Handle(PaginatedRequest query, CancellationToken cancellationToken)
	{
		var ticketsWithTotalCount = await ticketReadRepository.GetTicketsAsync(
			new PaginatedRequest
			{
				PageNumber = query.PageNumber,
				PageSize = query.PageSize,
				CreateBy = currentUser.Email!,
				IsActive = query.IsActive,
				StartDate = query.StartDate,
				EndDate = query.EndDate,
			}, cancellationToken);

		var tickets = mapper.Map<List<TicketDto>>(ticketsWithTotalCount.Items);

		return new PaginatedResultDto<TicketDto>(tickets, query.PageNumber, query.PageSize, ticketsWithTotalCount.TotalCount);
	}
}