using Application.Shared.Exceptions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.ChangeEmail;

public class ChangeEmailCommandHandler(UserManager<User> userManager) : IRequestHandler<ChangeEmailCommand>
{
	public async Task Handle(ChangeEmailCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		var user = await userManager.FindByIdAsync(request.CurrentEmail);
		if (user is null)
			throw new NotFoundException("User not found.");

		var isPasswordValid = await userManager.CheckPasswordAsync(user, request.Password);
		if (!isPasswordValid)
			throw new UnauthorizedAccessException("Invalid password.");

		var existingUser = await userManager.FindByEmailAsync(request.NewEmail);
		if (existingUser is not null && existingUser.Id != user.Id)
			throw new ValidationException(["Email is already in use."]);

		user.Email = request.NewEmail;
		user.NormalizedEmail = userManager.NormalizeEmail(request.NewEmail);

		var result = await userManager.UpdateAsync(user);
		if (!result.Succeeded)
			throw new ValidationException(result.Errors.Select(e => e.Description));
	}
}

