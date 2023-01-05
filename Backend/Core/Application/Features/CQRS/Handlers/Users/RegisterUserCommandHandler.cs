using Backend.Core.Application.Enums;
using Backend.Core.Application.Features.CQRS.Commands.Users;
using Backend.Core.Application.Interfaces;
using Backend.Core.Domain;
using MediatR;

namespace Backend.Core.Application.Features.CQRS.Handlers.Users;
public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest>
{
    private readonly IRepository<AppUser> _repository;

    public RegisterUserCommandHandler(IRepository<AppUser> repository) => _repository = repository;

    public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new AppUser
        {
            Password = request.Password,
            UserName = request.Username,
            AppRoleId = (int)RoleType.Member,
        });
        return Unit.Value;
    }
}
