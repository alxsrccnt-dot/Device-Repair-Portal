using Application.Common;
using Application.Monitoring.Dtos;
using MediatR;

namespace Application.Monitoring.Tickets;

public record GetUserTicketsQuery(int PageNumber, int PageSize) : IRequest<PaginatedResultDto<TicketDto>>;