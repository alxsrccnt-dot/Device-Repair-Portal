using Domain.Entities;

namespace Application.Identity.Shared.Token;

public interface ITokenProvider
{
	Task<string> GenerateJwtToken(User user);
}