using Application.Identity.Shared;
using MediatR;

namespace Application.Identity.LoginWithRefreshToken;

public record LoginWithRefreshTokenCommand(AuthenticationWithRefreshTokenRequest Request) : IRequest<AuthResponse>;