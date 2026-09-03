using DevFlow.BuildingBlocks.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFlow.BuildingBlocks.Web.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(this Result<T> result, ControllerBase controller)
    {
        if (result.IsSuccess)
        {
            return controller.Ok(result.Value);
        }

        return result.Error?.Type switch
        {
            ErrorType.Validation => controller.BadRequest(new
            {
                error = result.Error,
                validationFailures = result.ValidationFailures
            }),
            ErrorType.NotFound => controller.NotFound(result.Error),
            ErrorType.Conflict => controller.Conflict(result.Error),
            ErrorType.Unauthorized => controller.Unauthorized(result.Error),
            _ => controller.Problem(
                title: result.Error?.Code,
                detail: result.Error?.Message,
                statusCode: StatusCodes.Status500InternalServerError)
        };
    }
}
