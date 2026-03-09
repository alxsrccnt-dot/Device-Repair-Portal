using MediatR;

namespace Application.ChangePassword;

public record ChangePasswordCommand(ChangePasswordRequest Request) : IRequest<Unit>;

