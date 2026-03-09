using Application.Monitoring.Common;
using Application.Monitoring.Tickets.Dtos;
using Application.Services;
using AutoMapper;
using Infrastructure.Data.Repositories.Queries;
using Infrastructure.Data.Repositories.Queries.Models;
using MediatR;

namespace Application.Monitoring.Tickets;

public class GetTicketsQueryHandler(ICurrentUser currentUser, ITicketReadRepository ticketReadRepository, IMapper mapper)
	: GetTicketsBaseHandler(currentUser, ticketReadRepository, mapper), IRequestHandler<GetTicketsQuery, PaginatedResultDto<TicketDto>>
{
    public async Task<PaginatedResultDto<TicketDto>> Handle(GetTicketsQuery query, CancellationToken cancellationToken)
        => await base.Handle(new PaginatedRequest
		{
			PageNumber = query.PageNumber,
			PageSize = query.PageSize,
			CreateBy = query.UserEmail,
			IsActive = query.IsActive,
			StartDate = query.StartDate,
			EndDate = query.EndDate,
		}, cancellationToken);
}