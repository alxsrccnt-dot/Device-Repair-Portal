using Application.Shared.Identity;
using MediatR;

namespace Application.Register;
public record RegisterCommand(RegisterRequest request) : IRequest<AuthResponse>;