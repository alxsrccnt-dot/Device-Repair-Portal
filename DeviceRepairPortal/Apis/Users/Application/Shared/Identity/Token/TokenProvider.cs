using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Application.Shared.Identity.Token;

public class TokenProvider(UserManager<User> userManager, TokenSettings jwtSettings) : ITokenProvider
{
	public async Task<string> GenerateJwtToken(User user)
	{
		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret));
		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		var roles = await userManager.GetRolesAsync(user);

		var claims = new List<Claim>();
		claims.Add(new(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
		claims.Add(new(JwtRegisteredClaimNames.Email, user.Email!.ToString()));
		claims.Add(new(JwtRegisteredClaimNames.UniqueName, user.UserName!));
		claims.Add(new(ClaimTypes.Name, user.UserName!));
		claims.Add(new(ClaimTypes.Country, "Country"));

		if (await userManager.IsInRoleAsync(user, AppRoles.Admin))
		{
			claims.Add(new("scope", "admins.read"));
			claims.Add(new("scope", "admins.manage")); 
        }

        if (await userManager.IsInRoleAsync(user, AppRoles.Technician))
		{
            claims.Add(new("scope", "technicians.read"));
            claims.Add(new("scope", "technicians.manage"));
        }

        foreach (var role in roles)
        {
            claims.Add(new(ClaimTypes.Role, role));
        }

        var token = new JwtSecurityToken(
			issuer: jwtSettings.Issuer,
			audience: jwtSettings.Audience,
			claims: claims,
			expires: DateTime.UtcNow.AddMinutes(jwtSettings.ExpirationInMinutes),
			signingCredentials: creds);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}
