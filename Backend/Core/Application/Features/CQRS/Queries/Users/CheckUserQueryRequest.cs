using Backend.Core.Application.Dtos;
using MediatR;

namespace Backend.Core.Application.Features.CQRS.Queries.Users;
public class CheckUserQueryRequest : IRequest<CheckUserResponseDto>
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}
