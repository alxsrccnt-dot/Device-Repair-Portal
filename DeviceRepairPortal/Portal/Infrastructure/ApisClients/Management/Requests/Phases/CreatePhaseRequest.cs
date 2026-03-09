using Infrastructure.ApisClients.Common;

namespace Infrastructure.ApisClients.Management.Requests.Phases;

public record CreatePhaseRequest(Guid JobId, State State);