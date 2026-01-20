using Infrastructure.ApisClients.Management.Requests.Billings;
using Infrastructure.ApisClients.Management.Requests.Comments;
using Infrastructure.ApisClients.Management.Requests.Investigations;
using Infrastructure.ApisClients.Management.Requests.Jobs;
using Infrastructure.ApisClients.Management.Requests.Phases;
using Infrastructure.ApisClients.Management.Requests.Tickets;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.ApisClients.Management;

public class ManagementServicesClient(HttpClient httpClient) : BaseApiClient(httpClient), IManagementServicesClient
{
    public async Task<IResult> CreateTicketAsync(CreateTicketRequest request)
        => await PostAsync<CreateTicketRequest, IResult>(
            ManagementApiRoutesConstants.CreateTicketEndpointRoute, request);

    public async Task<IResult> CreateJobAsync(CreateJobRequest requst)
       => await PostAsync<CreateJobRequest, IResult>(
                ManagementApiRoutesConstants.CreateJobEndpointRoute, requst);

    public async Task<IResult> CreateJobCommentAsync(CreateCommentRequest request)
        => await PostAsync<CreateCommentRequest, IResult>(
            ManagementApiRoutesConstants.CreateJobCommentEndpointRoute, request);

    public async Task<IResult> CreateJoBillingbAsync(CreateBillingInformationRequest request)
        => await PostAsync<CreateBillingInformationRequest, IResult>(
            ManagementApiRoutesConstants.CreateJobBillingEndpointRoute, request);

    public async Task<IResult> CreateJobInvestigationAsync(CreateInvestigationRequest request)
        => await PostAsync<CreateInvestigationRequest, IResult>(
            ManagementApiRoutesConstants.CreateJobInvestigationEndpointRoute, request);

    public async Task<IResult> CreateJobPhaseAsync(CreatePhaseRequest request)
    {
        if (request.State == State.Repair)
            return await PostAsync<CreatePhaseRequest, IResult>(
                ManagementApiRoutesConstants.CreateJobRepairEndpointRoute, request);

        if (request.State == State.Return)
            return await PostAsync<CreatePhaseRequest, IResult>(
                ManagementApiRoutesConstants.CreateJobReturnRoute, request);

        throw new InvalidCastException();
    }
}