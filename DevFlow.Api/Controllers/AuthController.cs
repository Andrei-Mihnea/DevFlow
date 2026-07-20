using Api.Contracts.Auth;
using Application.Abstractions.Messaging;
using Application.Abstractions.Results;
using Application.Abstractions.Validations;
using Application.Auth.Register;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

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

        return ToActionResult(result);
    }

    private IActionResult ToActionResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        if (result.Error?.Type == ErrorType.Validation)
        {
            return BadRequest(new
            {
                error = result.Error,
                validationFailures = result.ValidationFailures
            });
        }

        return Problem(
            title: result.Error?.Code,
            detail: result.Error?.Message,
            statusCode: StatusCodes.Status500InternalServerError);
    }
}
