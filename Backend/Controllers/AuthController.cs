using Backend.Core.Application.Features.CQRS.Commands.Users;
using Backend.Core.Application.Features.CQRS.Queries.Users;
using Backend.Infrastructure.Tools;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator; 
    public AuthController(IMediator mediator) => _mediator = mediator;
    
    /// <summary>
    /// Create User
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> Register(RegisterUserCommandRequest request) => Created("", await _mediator.Send(request));

    [HttpPost("[action]")] //TODO: if control icin refaktor edilmeli
    public async Task<IActionResult> Login(CheckUserQueryRequest request) 
    { 
        var dto = await _mediator.Send(request);
        if(dto.IsExist)
        { 
            return Created("", JwtGenerator.GenerateToken(dto));
        }
        else
        {
            return BadRequest("Kullanıcı adı veya şifre hatalı");
        }
    }
}
