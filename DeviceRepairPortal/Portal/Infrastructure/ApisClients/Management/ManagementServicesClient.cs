using Infrastructure.ApisClients.Management.Requests.Jobs;
using Infrastructure.ApisClients.Management.Requests.Tickets;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.ApisClients.Management;

public class ManagementServicesClient(HttpClient httpClient) : BaseApiClient(httpClient), IManagementServicesClient
{
    public async Task<IResult> CreateJobAsync(CreateJobRequest requst)
       => await PostAsync<CreateJobRequest, IResult>(
                ManagementApiRoutesConstants.CreateJobEndpointRoute, requst);

    public async Task<IResult> CreateTicketAsync(CreateTicketRequest request)
        => await PostAsync<CreateTicketRequest, IResult>(
            ManagementApiRoutesConstants.CreateTicketEndpointRoute, request);
}