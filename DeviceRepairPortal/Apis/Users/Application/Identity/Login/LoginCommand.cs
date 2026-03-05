using Application.Identity.Shared;
using MediatR;

namespace Application.Identity.Login;

public record LoginCommand(AuthenticationRequest Request) : IRequest<AuthResponse>;