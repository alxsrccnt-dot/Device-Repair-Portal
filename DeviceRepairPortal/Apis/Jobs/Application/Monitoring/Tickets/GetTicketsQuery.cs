using Application.Monitoring.Common;
using Application.Monitoring.Tickets.Dtos;
using MediatR;

namespace Application.Monitoring.Tickets;

public record GetTicketsQuery(int PageNumber, int PageSize,
	string? UserEmail = null, bool? IsActive = null,
	DateTime? StartDate = null, DateTime? EndDate = null) : IRequest<PaginatedResultDto<TicketDto>>;