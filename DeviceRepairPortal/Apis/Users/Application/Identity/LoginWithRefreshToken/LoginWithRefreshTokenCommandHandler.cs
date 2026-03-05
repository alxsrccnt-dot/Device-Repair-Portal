using Application.Identity.Shared;
using Application.Identity.Shared.Token;
using Domain.Entities;
using Infrastructure.Data.Repositories.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Identity.LoginWithRefreshToken;

public class LoginWithRefreshTokenCommandHandler(IUserReadRepository readRepository, SignInManager<User> signInManager,
    ITokenProvider jwtProvider, IRefreshTokenService refreshTokenService) : IRequestHandler<LoginWithRefreshTokenCommand, AuthResponse>
{
    public async Task<AuthResponse> Handle(LoginWithRefreshTokenCommand command, CancellationToken cancellationToken)
    {
        var refreshTokenValue = command.Request.RefreshToken;
        var userId = await refreshTokenService.ValidateUserSesionAsync(refreshTokenValue, cancellationToken);

        if (string.IsNullOrEmpty(userId))
            throw new UnauthorizedAccessException("Invalid refresh token or refresh token is expired.");
        
        var user = await readRepository.GetByIdAsync(userId, cancellationToken);
        var accessToken = await jwtProvider.GenerateJwtToken(user);
		
        return new AuthResponse(accessToken, refreshTokenValue);
    }
}