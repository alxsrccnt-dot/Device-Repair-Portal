using DeviceRepairPortal.Infrastructure.ApisClients.Constants;
using DeviceRepairPortal.Infrastructure.Requests.Auth;
using DeviceRepairPortal.Models.Account;

namespace DeviceRepairPortal.Infrastructure.ApisClients;

public class AuthServiceClient(HttpClient httpClient) : BaseApiClient(httpClient), IAuthServicesClient
{
    public async Task<string> GetTokenAsync(LoginViewModel model)
        => await PostAsync<AuthenticationRequest, string>(
            AuthApiRoutesConstants.LoginEndpointRoute,
            new AuthenticationRequest(model.Email, model.Password));

    public async Task<string> CreateAccountAndGetTokenAsync(RegisterViewModel model)
        => await PostAsync<RegisterRequest, string>(
            AuthApiRoutesConstants.RegisterEndpointRoute,
            new RegisterRequest(model.Username, model.Email, model.Password));
}