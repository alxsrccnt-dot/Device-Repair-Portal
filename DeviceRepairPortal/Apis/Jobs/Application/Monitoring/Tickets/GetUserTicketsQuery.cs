using Application.Monitoring.Common;
using Application.Monitoring.Tickets.Dtos;
using MediatR;

namespace Application.Monitoring.Tickets;

public record GetUserTicketsQuery(int PageNumber, int PageSize, bool? IsActive = null,
	DateTime? StartDate = null, DateTime? EndDate = null) : IRequest<PaginatedResultDto<TicketDto>>;