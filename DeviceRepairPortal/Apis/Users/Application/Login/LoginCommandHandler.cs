using Application.Common.Exceptions;
using Application.Common.Token;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Login;

public class LoginCommandHandler(UserManager<User> userManager,
	SignInManager<User> signInManager,
	ITokenService jwtService) : IRequestHandler<LoginCommand, string>
{
	public async Task<string> Handle(LoginCommand command, CancellationToken cancellationToken)
	{
		var user = await userManager.FindByEmailAsync(command.request.Email);
		if (user is null)
			throw new UnauthorizedAccessException("Invalid credentials");

		if (!user.IsActive)
			throw new InactiveException("Invalid credentials");

		var result = await signInManager.CheckPasswordSignInAsync(user, command.request.Password, lockoutOnFailure: false);

		if (!result.Succeeded)
			throw new UnauthorizedAccessException("Invalid credentials");

		return await jwtService.GenerateJwtToken(user);
	}
}