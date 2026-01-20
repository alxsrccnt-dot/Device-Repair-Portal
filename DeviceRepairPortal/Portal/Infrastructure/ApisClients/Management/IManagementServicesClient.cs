using Infrastructure.ApisClients.Management.Requests.Billings;
using Infrastructure.ApisClients.Management.Requests.Comments;
using Infrastructure.ApisClients.Management.Requests.Investigations;
using Infrastructure.ApisClients.Management.Requests.Jobs;
using Infrastructure.ApisClients.Management.Requests.Phases;
using Infrastructure.ApisClients.Management.Requests.Tickets;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.ApisClients.Management;

public interface IManagementServicesClient
{
    Task<IResult> CreateTicketAsync(CreateTicketRequest requst);
    Task<IResult> CreateJobAsync(CreateJobRequest requst);
    Task<IResult> CreateJobInvestigationAsync(CreateInvestigationRequest requst);
    Task<IResult> CreateJoBillingbAsync(CreateBillingInformationRequest requst);
    Task<IResult> CreateJobPhaseAsync(CreatePhaseRequest requst);
    Task<IResult> CreateJobCommentAsync(CreateCommentRequest requst);
}
