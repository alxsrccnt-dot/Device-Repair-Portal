using Application.Common.Services;
using Application.Monitoring.Dtos;
using AutoMapper;
using Infrastructure.Data.Repositories.Queries;
using Infrastructure.Data.Repositories.Queries.Models;
using MediatR;

namespace Application.Monitoring.Tickets;

public class GetTicketsHandler(ICurrentUser currentUser, ITicketReadRepository ticketReadRepository, IMapper mapper) : IRequestHandler<GetTicketsQuery, PaginatedResultDto<TicketDto>>
{
    public async Task<PaginatedResultDto<TicketDto>> Handle(GetTicketsQuery query, CancellationToken cancellationToken)
    {
        var request = query.Request;
        var ticketsWithTotalCount = await ticketReadRepository.GetUserTicketsAsync(
            new TicketsRequest(request.UserEmail, request.IsActive, request.PageNumber, request.PageSize), cancellationToken);

        var tickets = mapper.Map<List<TicketDto>>(ticketsWithTotalCount.Items);

        return new PaginatedResultDto<TicketDto>(tickets, request.PageNumber, request.PageSize, ticketsWithTotalCount.TotalCount);
    }
}