using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Common.Token;

public class TokenService(UserManager<User> userManager, TokenSettings jwtSettings) : ITokenService
{
	public async Task<string> GenerateJwtToken(User user)
	{
		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret));
		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		var roles = await userManager.GetRolesAsync(user);

		var claims = new List<Claim>
		{
			new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
			new Claim(JwtRegisteredClaimNames.Email, user.Email!.ToString()),
			new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName!)
		};

		if (await userManager.IsInRoleAsync(user, AppRoles.Admin))
		{
			claims.Add(new Claim("scope", "admins.read"));
			claims.Add(new Claim("scope", "admins.manage"));
        }

        if (await userManager.IsInRoleAsync(user, AppRoles.Technician))
		{
            claims.Add(new Claim("scope", "technicians.read"));
            claims.Add(new Claim("scope", "technicians.manage"));
        }

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
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
