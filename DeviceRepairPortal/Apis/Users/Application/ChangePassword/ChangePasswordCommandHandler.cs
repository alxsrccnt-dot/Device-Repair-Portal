using Application.Shared.Exceptions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.ChangePassword;

public class ChangePasswordCommandHandler(UserManager<User> userManager) : IRequestHandler<ChangePasswordCommand, Unit>
{
	public async Task<Unit> Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		var user = await userManager.FindByEmailAsync(request.UserEmail);
		if (user is null)
			throw new NotFoundException("User not found.");

		var isPasswordValid = await userManager.CheckPasswordAsync(user, request.OldPassword);
		if (!isPasswordValid)
			throw new UnauthorizedAccessException("Current password is incorrect.");

		var result = await userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
		if (!result.Succeeded)
			throw new ValidationException(result.Errors.Select(e => e.Description));

		return Unit.Value;
	}
}

