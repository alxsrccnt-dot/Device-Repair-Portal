using MediatR;

namespace Application.Login;

public record LoginCommand(AuthenticationRequest request) : IRequest<string>;