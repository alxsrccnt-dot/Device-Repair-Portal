using Application.Login;
using MediatR;

namespace Application.Register;
public record RegisterCommand(RegisterRequest request) : IRequest<string>;