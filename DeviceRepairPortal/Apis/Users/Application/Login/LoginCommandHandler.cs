using Application.Common.Exceptions;
using Application.Common.Token;
using Domain.Entities;
using Infrastructure.Data.Repositories.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Login;

public class LoginCommandHandler(IUserReadRepository readRepository, SignInManager<User> signInManager,
	ITokenProvider jwtProvider, IRefreshTokenService refreshTokenService) : IRequestHandler<LoginCommand, AuthResponse>
{
	public async Task<AuthResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
	{
		var user = await readRepository.GetUserByEmailAsync(command.request.Email, cancellationToken);
		if (user is null)
			throw new UnauthorizedAccessException("Invalid credentials");

		if (!user.IsActive)
			throw new InactiveException("Invalid credentials");

		var result = await signInManager.CheckPasswordSignInAsync(user, command.request.Password, lockoutOnFailure: false);
		if (!result.Succeeded)
			throw new UnauthorizedAccessException("Invalid credentials");

		var refreshTokenValue = user.RefreshToken.Token;
		await refreshTokenService.ValidateAsync(refreshTokenValue);
		var accessToken = await jwtProvider.GenerateJwtToken(user);
		
		return new AuthResponse(accessToken, user.RefreshToken.Token);
	}
}