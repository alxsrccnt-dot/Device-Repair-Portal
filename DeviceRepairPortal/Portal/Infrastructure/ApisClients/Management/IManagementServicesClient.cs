using Infrastructure.ApisClients.Management.Requests.Jobs;
using Infrastructure.ApisClients.Management.Requests.Tickets;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.ApisClients.Management;

public interface IManagementServicesClient
{
    Task<IResult> CreateTicketAsync(CreateTicketRequest requst);
    Task<IResult> CreateJobAsync(CreateJobRequest requst);
}
