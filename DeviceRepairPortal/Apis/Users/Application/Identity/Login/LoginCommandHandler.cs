using Application.Identity.Shared;
using Application.Identity.Shared.Token;
using Application.Shared.Exceptions;
using Domain.Entities;
using Infrastructure.Data.Repositories.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Identity.Login;

public class LoginCommandHandler(IUserReadRepository readRepository, SignInManager<User> signInManager,
	ITokenProvider jwtProvider, IRefreshTokenService refreshTokenService) : IRequestHandler<LoginCommand, AuthResponse>
{
	public async Task<AuthResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
	{
		var user = await readRepository.GetByEmailAsync(command.Request.Email, cancellationToken);
		if (user is null)
			throw new UnauthorizedAccessException("Invalid credentials");

		if (!user.IsActive)
			throw new InactiveException("Invalid credentials");

		var result = await signInManager.CheckPasswordSignInAsync(user, command.Request.Password, lockoutOnFailure: false);
		if (!result.Succeeded)
			throw new UnauthorizedAccessException("Invalid credentials");

		var refreshToken = user.RefreshToken;
		await refreshTokenService.ValidateAsync(refreshToken, cancellationToken);
		var accessToken = await jwtProvider.GenerateJwtToken(user);
		
		return new AuthResponse(accessToken, refreshToken.Token);
	}
}