using MediatR;

namespace Unlocker.Application.Users.Commands;

public record CreateUserCommand(string Name, string Email, string Password) : IRequest<Guid>;