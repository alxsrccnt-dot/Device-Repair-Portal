using Infrastructure.ApisClients.User.Requests.Auth;

namespace Infrastructure.ApisClients.User;

public interface IAuthServicesClient
{
    Task<string> GetTokenAsync(AuthenticationRequest request);
    Task<string> CreateAccountAndGetTokenAsync(RegisterRequest request);
}