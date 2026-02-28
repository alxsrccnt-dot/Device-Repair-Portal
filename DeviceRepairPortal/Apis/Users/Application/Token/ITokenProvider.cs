using Domain.Entities;

namespace Application.Common.Token;

public interface ITokenProvider
{
	Task<string> GenerateJwtToken(User user);
}