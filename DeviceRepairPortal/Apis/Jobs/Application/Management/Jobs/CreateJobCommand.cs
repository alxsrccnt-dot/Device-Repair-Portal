using MediatR;

namespace Application.Management.Jobs;

public record CreateJobCommand(CreateJobRequest Request) : IRequest;