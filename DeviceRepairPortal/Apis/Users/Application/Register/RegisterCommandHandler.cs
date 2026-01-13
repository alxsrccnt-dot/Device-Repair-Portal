using Application.Common;
using Application.Common.Token;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Application.Register;

public class RegisterCommandHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,
			ITokenService jwtService) : IRequestHandler<RegisterCommand, string>
{
	public async Task<string> Handle(RegisterCommand command, CancellationToken cancellationToken)
	{
		//todo: add more validations (e.g., check if user already exists)
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
				result.Errors.Select(e => e.Description).First());
		
		await userManager.AddToRoleAsync(user, AppRoles.User);

		return await jwtService.GenerateJwtToken(user);
	}
}