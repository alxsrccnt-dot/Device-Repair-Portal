using Application.Shared.Exceptions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.ChangeUserRole;

public class ChangeRoleCommandHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : IRequestHandler<ChangeRoleCommand>
{
	public async Task Handle(ChangeRoleCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		var existentUser = await userManager.FindByEmailAsync(request.UserEmail);
		if (existentUser is null)
			throw new NotFoundException("The specified user can't be found.");

		await userManager.AddToRoleAsync(existentUser, request.NewClaim);
	}
}