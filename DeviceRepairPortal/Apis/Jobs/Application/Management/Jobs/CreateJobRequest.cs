namespace Application.Management.Jobs;

public record CreateJobRequest(Guid TicketId, string Comment);