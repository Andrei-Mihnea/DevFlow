
using DevFlow.BuildingBlocks.Messaging;
using DevFlow.BuildingBlocks.Web.Extensions;
using DevFlow.Workspaces.Api.Contracts.Workspaces;
using DevFlow.Workspaces.Application.Workspaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFlow.Workspaces.Api.Controllers;

[ApiController]
[Route("api/workspaces")]
public sealed class WorkspacesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateWorkspace(
        [FromBody] CreateWorkspaceRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateWorkspaceCommand(
            request.Name,
            request.Slug,
            request.CreatedByUserId);

        var result = await mediator.SendAsync(command, cancellationToken);

        return result.ToActionResult(this);
    }
}
