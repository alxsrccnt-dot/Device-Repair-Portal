using Application.Monitoring.Dtos;
using MediatR;

namespace Application.Monitoring.Tickets;

public record GetTicketsQuery(string UserEmail, bool IsActive, int PageNumber, int PageSize) : IRequest<PaginatedResultDto<TicketDto>>;