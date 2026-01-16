using Infrastructure.ApisClients.Management.Requests.Tickets;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.ApisClients.Management;

public class ManagementServicesClient(HttpClient httpClient) : BaseApiClient(httpClient), IManagementServicesClient
{
    public async Task<IResult> CreateTicket(CreateTicketRequest request)
        => await PostAsync<CreateTicketRequest, IResult>(
            ManagementApiRoutesConstants.CreateTicketEndpointRoute, request);
}