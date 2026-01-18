using Infrastructure.ApisClients.User.Requests.Auth;

namespace Infrastructure.ApisClients.User;

public class AuthServiceClient(HttpClient httpClient) : BaseApiClient(httpClient), IAuthServicesClient
{
    public async Task<string> GetTokenAsync(AuthenticationRequest request)
        => await PostAsync<AuthenticationRequest, string>(
            AuthApiRoutesConstants.LoginEndpointRoute, request);

    public async Task<string> CreateAccountAndGetTokenAsync(RegisterRequest request)
        => await PostAsync<RegisterRequest, string>(
            AuthApiRoutesConstants.RegisterEndpointRoute, request);
}