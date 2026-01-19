using Application.Common;
using Application.Common.Exceptions;
using Application.Common.Token;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Register;

public class RegisterCommandHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,
			ITokenService jwtService) : IRequestHandler<RegisterCommand, string>
{
	public async Task<string> Handle(RegisterCommand command, CancellationToken cancellationToken)
	{
		var request = ValidateRequest(command.request);
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
		
		await userManager.AddToRoleAsync(user, AppRoles.User);

		return await jwtService.GenerateJwtToken(user);
	}

    private RegisterRequest ValidateRequest(RegisterRequest request)
    {
        var validationErros = new List<string>();

        if (string.IsNullOrWhiteSpace(request.UserName))
            validationErros.Add("UserName can not be empty");

        if (string.IsNullOrWhiteSpace(request.Email))
            validationErros.Add("Email can not be empty");

        if (string.IsNullOrWhiteSpace(request.Password))
            validationErros.Add("Password can not be empty");

        if (validationErros.Any())
            throw new ValidationException(validationErros);

        return request;
    }
}