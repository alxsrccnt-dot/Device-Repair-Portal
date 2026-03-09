using MediatR;

namespace Application.Logout;

public record LogoutCommand(LogoutRequest Request) : IRequest;