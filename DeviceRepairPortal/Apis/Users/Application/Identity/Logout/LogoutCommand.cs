using MediatR;

namespace Application.Identity.Logout;

public record LogoutCommand(LogoutRequest Request) : IRequest;