using DeviceRepairPortal.Models.Account;

namespace DeviceRepairPortal.Infrastructure.ApisClients;

public interface IAuthServicesClient
{
    Task<string> GetTokenAsync(LoginViewModel model);
    Task<string> CreateAccountAndGetTokenAsync(RegisterViewModel model);
}