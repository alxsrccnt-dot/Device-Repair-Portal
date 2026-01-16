using Infrastructure.ApisClients.Management.Requests.Tickets;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.ApisClients.Management;

public interface IManagementServicesClient
{
    Task<IResult> CreateTicket(CreateTicketRequest requst);
}
