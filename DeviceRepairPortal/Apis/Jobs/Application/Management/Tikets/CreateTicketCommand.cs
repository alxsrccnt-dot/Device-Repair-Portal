using MediatR;

namespace Application.Management.Tikets;

public record CreateTicketCommand(CreateTicketRequest Request) : IRequest;