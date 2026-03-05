using Application.Identity.Shared;
using MediatR;

namespace Application.Identity.Register;
public record RegisterCommand(RegisterRequest request) : IRequest<AuthResponse>;