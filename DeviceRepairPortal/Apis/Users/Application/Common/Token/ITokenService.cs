using Domain.Entities;

namespace Application.Common.Token;

public interface ITokenService
{
	Task<string> GenerateJwtToken(User user);
}