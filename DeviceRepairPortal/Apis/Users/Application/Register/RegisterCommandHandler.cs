using Application.Shared.Exceptions;
using Application.Shared.Identity;
using Application.Shared.Identity.Token;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Register;

public class RegisterCommandHandler(UserManager<User> userManager,
	IRefreshTokenService refreshTokenService, ITokenProvider jwtProvider) : IRequestHandler<RegisterCommand, AuthResponse>
{
	public async Task<AuthResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
	{
		var request = command.request;
		var user = new User
		{
			UserName = request.UserName,
			Email = request.Email,
			IsActive = true
		};

		var result = await userManager.CreateAsync(user, request.Password);
		if (!result.Succeeded)
			throw new ValidationException(
				result.Errors.Select(e => e.Description));

		var result1 = await userManager.AddToRoleAsync(user, AppRoles.User);
		
		var accessToken = await jwtProvider.GenerateJwtToken(user);
		var refreshToken = await refreshTokenService.GenerateAsync(user.Id, cancellationToken);
		return new AuthResponse(accessToken, refreshToken);
	}
}