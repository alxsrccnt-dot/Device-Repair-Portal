using Domain.Entities;

namespace Application.Shared.Identity.Token;

public interface ITokenProvider
{
	Task<string> GenerateJwtToken(User user);
}