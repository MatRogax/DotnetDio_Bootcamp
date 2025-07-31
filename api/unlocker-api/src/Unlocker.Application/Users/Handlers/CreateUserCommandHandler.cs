using Unlocker.Application.Abstractions.Persistence;
using Unlocker.Application.Users.Commands;

namespace Unlocker.Application.Users.Handlers;

using MediatR;
using Unlocker.Domain.Entities;

public class CreateUserCommandHandler(IUserRepository repository) : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            Password= HashPassword(request.Password),
            CreateAt = DateTime.UtcNow,
            UpdateAt = DateTime.UtcNow
        };

        return await repository.CreateAsync(user);
    }

    private string HashPassword(string plainPassword)
    {
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(plainPassword));
    }
}