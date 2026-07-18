using Api.Contracts.Auth;
using Application.Abstractions.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    public IActionResult RegisterUser([FromBody] RegisterUserRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException("Registration is not implemented");
    }

}