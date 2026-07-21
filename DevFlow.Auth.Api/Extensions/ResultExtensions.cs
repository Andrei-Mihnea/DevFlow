using DevFlow.BuildingBlocks.Results;
using Microsoft.AspNetCore.Mvc;

namespace DevFlow.Auth.Api.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(this Result<T> result, ControllerBase controller)
    {
        if (result.IsSuccess)
        {
            return controller.Ok(result.Value);
        }

        if (result.Error?.Type == ErrorType.Validation)
        {
            return controller.BadRequest(new
            {
                error = result.Error,
                validationFailures = result.ValidationFailures
            });
        }

        return controller.Problem(
            title: result.Error?.Code,
            detail: result.Error?.Message,
            statusCode: StatusCodes.Status500InternalServerError);
    }
}
