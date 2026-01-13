using MediatR;

namespace Application.ChangeUserClaim;

public record ChangeUserClaimsCommand(ChangeUserClaimRequest Request) : IRequest;