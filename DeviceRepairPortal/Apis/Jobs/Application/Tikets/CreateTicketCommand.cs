using MediatR;

namespace Application.Tikets;

public record CreateTicketCommand(CreateTicketRequest Request) : IRequest;