using MediatR;

namespace Application.ChangeEmail;

public record ChangeEmailCommand(ChangeEmailRequest Request) : IRequest;