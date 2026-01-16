using Application.Common.Services;
using Application.Monitoring.Dtos;
using AutoMapper;
using Infrastructure.Data.Repositories.Queries;
using Infrastructure.Data.Repositories.Queries.Models;
using MediatR;

namespace Application.Monitoring.Tickets;

public class GetUserTicketsHandler(ICurrentUser currentUser, ITicketReadRepository ticketReadRepository, IMapper mapper) : IRequestHandler<GetUserTicketsQuery, PaginatedResultDto<TicketDto>>
{
    public async Task<PaginatedResultDto<TicketDto>> Handle(GetUserTicketsQuery request, CancellationToken cancellationToken)
    {
        var ticketsWithTotalCount = await ticketReadRepository.GetUserTicketsAsync(
            new PaginatedRequest<string>(currentUser.Email!, request.PageNumber, request.PageSize));
        
        var tickets = mapper.Map<List<TicketDto>>(ticketsWithTotalCount.Items);

        return new PaginatedResultDto<TicketDto>(tickets, request.PageNumber, request.PageSize, ticketsWithTotalCount.TotalCount);
    }
}