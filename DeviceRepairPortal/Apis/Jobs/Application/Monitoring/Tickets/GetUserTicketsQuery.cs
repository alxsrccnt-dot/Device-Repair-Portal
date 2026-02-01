using Application.Monitoring.Common;
using Application.Monitoring.Tickets.Dtos;
using MediatR;

namespace Application.Monitoring.Tickets;

public record GetUserTicketsQuery(int PageNumber, int PageSize) : IRequest<PaginatedResultDto<TicketDto>>;