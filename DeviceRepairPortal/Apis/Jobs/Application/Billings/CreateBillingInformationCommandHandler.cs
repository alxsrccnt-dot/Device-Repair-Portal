using Application.Common.Exceptions;
using Application.Common.Services;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data.Repositories.Commands;
using Infrastructure.Data.Repositories.Queries;
using MediatR;

namespace Application.Billings;

public class CreateBillingInformationCommandHandler(ICurrentUser currentUser,
    IReadRepository<Job> jobReadRepository,
    ICreateRepository<BillingInformation> billingInformationCreateRepository, ICreateRepository<Phase> phaseCreateRepository) : IRequestHandler<CreateBillingInformationCommand>
{
    public async Task Handle(CreateBillingInformationCommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;

        var job = await jobReadRepository.GetByIdAsync(request.JobId, cancellationToken);
        if (job == null)
            throw new NotFoundException("The job can not be found.");

        var billingInformation = new BillingInformation(request.JobId, request.Amount, currentUser.Email!, currentUser.UserName!, DateTime.UtcNow);
        await billingInformationCreateRepository.CreateAsync(billingInformation, cancellationToken);

        var phase = new Phase(request.JobId, State.Billing, currentUser.Email!, currentUser.UserName!, billingInformation.CreateAt);
        await phaseCreateRepository.CreateAsync(phase, cancellationToken);
    }
}
