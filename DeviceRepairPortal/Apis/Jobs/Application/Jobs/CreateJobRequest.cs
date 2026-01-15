namespace Application.Jobs;

public record CreateJobRequest(Guid TicketId, string Comment);