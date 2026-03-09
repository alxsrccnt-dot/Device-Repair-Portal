using Application.Shared.Identity.Token;
using MediatR;

namespace Application.Logout;

public class LogoutCommandHandler(IRefreshTokenService refreshTokenService  ) : IRequestHandler<LogoutCommand>
{
    public async Task Handle(LogoutCommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;
        await refreshTokenService.RevokeAsync(request.Token, cancellationToken);
    }
}