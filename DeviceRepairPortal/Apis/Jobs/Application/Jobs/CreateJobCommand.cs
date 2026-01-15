using MediatR;

namespace Application.Jobs;

public record CreateJobCommand(CreateJobRequest Request) : IRequest;