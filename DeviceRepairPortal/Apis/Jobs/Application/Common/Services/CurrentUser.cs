using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Common.Services;

internal class CurrentUser(IHttpContextAccessor httpContextAccessor) : ICurrentUser
{
	private ClaimsPrincipal? User => httpContextAccessor.HttpContext?.User;

	public bool IsAuthenticated =>
		User?.Identity?.IsAuthenticated ?? false;

	public string? UserId =>
		User?.FindFirstValue(ClaimTypes.NameIdentifier)
		?? User?.FindFirstValue(JwtRegisteredClaimNames.Sub);

	public string? Email =>
		User?.FindFirstValue(JwtRegisteredClaimNames.Email)
		?? User?.FindFirstValue(ClaimTypes.Email);

	public string? UserName =>
		User?.FindFirstValue(JwtRegisteredClaimNames.UniqueName)
		?? User?.FindFirstValue(ClaimTypes.Name);
}
