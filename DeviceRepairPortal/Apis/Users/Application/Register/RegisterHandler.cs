using Application.Common;
using Application.Common.Exceptions;
using Application.Common.Token;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Register;

public class RegisterHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,
			ITokenService jwtService) : IRequestHandler<RegisterCommand, string>
{
	public async Task<string> Handle(RegisterCommand command, CancellationToken cancellationToken)
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
		return await jwtService.GenerateJwtToken(user);
	}
}