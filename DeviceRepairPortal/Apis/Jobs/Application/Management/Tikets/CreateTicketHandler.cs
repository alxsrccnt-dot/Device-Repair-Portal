using Application.Exceptions;
using Application.Services;
using Domain.Entities;
using Infrastructure.Data.Repositories.Commands;
using Infrastructure.Data.Repositories.Queries;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Application.Management.Tikets;

public class CreateTicketHandler(ICurrentUser currentUser, ICreateRepository<Ticket> ticketCreateRepository, IReadIssuesRepositories readIssuesRepositories) : IRequestHandler<CreateTicketCommand>
{
    public async Task Handle(CreateTicketCommand command, CancellationToken cancellationToken)
    {
        var request = ValidateRequest(command.Request);
        
        var device = new Device(request.Brand, request.Model, request.SerialNumber);
        var ticket = new Ticket(request.Description, device, currentUser.Email!, currentUser.UserName!, DateTime.UtcNow);
        if (request.IssuesIds.Any())
        {
            var issues = await readIssuesRepositories.GetIssuesByIds(request.IssuesIds, cancellationToken);
            ticket.Issues = issues;
        }

        await ticketCreateRepository.CreateAsync(ticket, cancellationToken);
    }

    private static CreateTicketRequest ValidateRequest(CreateTicketRequest request)
    {
        var validationErros = new List<string>();

        if (string.IsNullOrWhiteSpace(request.Description))
            validationErros.Add("Description can not be empty");

        if (string.IsNullOrWhiteSpace(request.Brand))
            validationErros.Add("Brand can not be empty");
        
        if (string.IsNullOrWhiteSpace(request.Model))
            validationErros.Add("Model can not be empty");
        
        if (string.IsNullOrWhiteSpace(request.SerialNumber))
            validationErros.Add("SerialNumber can not be empty");

        if (!validationErros.IsNullOrEmpty())
            throw new ValidationException(validationErros);

        return request;
    }
}
