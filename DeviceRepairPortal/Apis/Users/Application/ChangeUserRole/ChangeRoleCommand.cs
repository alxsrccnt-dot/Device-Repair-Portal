using MediatR;

namespace Application.ChangeUserRole;

public record ChangeRoleCommand(ChangeRoleRequest Request) : IRequest;