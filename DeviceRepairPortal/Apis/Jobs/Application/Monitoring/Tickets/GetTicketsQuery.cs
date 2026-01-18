using Application.Monitoring.Dtos;
using MediatR;

namespace Application.Monitoring.Tickets;

public record GetTicketsQuery(GetTicketsRequest Request) : IRequest<PaginatedResultDto<TicketDto>>;