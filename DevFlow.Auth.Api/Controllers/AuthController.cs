using DevFlow.Auth.Api.Contracts.Auth;
using DevFlow.Auth.Application.Register;
using DevFlow.BuildingBlocks.Messaging;
using DevFlow.BuildingBlocks.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DevFlow.Auth.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var command = new RegisterUserCommand(
            request.Email,
            request.Password,
            request.ReTypedPassword,
            request.FirstName,
            request.LastName);

        var result = await mediator.SendAsync(command, cancellationToken);

        return result.ToActionResult(this);
    }
}
