using Application.Shared.Identity;
using MediatR;

namespace Application.Login;

public record LoginCommand(AuthenticationRequest Request) : IRequest<AuthResponse>;