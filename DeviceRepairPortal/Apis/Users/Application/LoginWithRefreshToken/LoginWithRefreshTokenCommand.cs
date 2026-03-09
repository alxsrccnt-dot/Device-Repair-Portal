using Application.Shared.Identity;
using MediatR;

namespace Application.LoginWithRefreshToken;

public record LoginWithRefreshTokenCommand(AuthenticationWithRefreshTokenRequest Request) : IRequest<AuthResponse>;