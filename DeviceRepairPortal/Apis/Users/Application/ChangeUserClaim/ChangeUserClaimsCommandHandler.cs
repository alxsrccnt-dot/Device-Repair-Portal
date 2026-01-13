using Application.Exceptions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.ChangeUserClaim;

public class ChangeUserClaimsCommandHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : IRequestHandler<ChangeUserClaimsCommand>
{
	public async Task Handle(ChangeUserClaimsCommand command, CancellationToken cancellationToken)
	{
		//string[] roles =
		//[
		//	AppRoles.Admin,
		//	AppRoles.User,
		//	AppRoles.Manager
		//	];

		//foreach (var role in roles)
		//{
		//	if (!await roleManager.RoleExistsAsync(role))
		//	{
		//		await roleManager.CreateAsync(new IdentityRole(role));
		//	}
		//}

		var request = command.Request;

		var existentUser = await userManager.FindByEmailAsync(request.UserEmail);
		if (existentUser is null)
			throw new NotFoundException("The specified user can't be found.");

		await userManager.AddToRoleAsync(existentUser, request.NewClaim);
	}
}