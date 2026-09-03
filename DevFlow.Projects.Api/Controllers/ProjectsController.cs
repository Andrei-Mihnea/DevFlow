using DevFlow.BuildingBlocks.Messaging;
using DevFlow.BuildingBlocks.Web.Extensions;
using DevFlow.Projects.Api.Contracts.Projects;
using DevFlow.Projects.Api.Contracts.ProjectTasks;
using DevFlow.Projects.Application.Projects;
using DevFlow.Projects.Application.ProjectTasks;
using Microsoft.AspNetCore.Mvc;

namespace DevFlow.Projects.Api.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProject(
        [FromBody] CreateProjectRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateProjectCommand(
            request.WorkspaceId,
            request.Name,
            request.Slug,
            request.Description,
            request.CreatedByUserId);

        var result = await mediator.SendAsync(command, cancellationToken);

        return result.ToActionResult(this);
    }

    [HttpPost("{projectId:guid}/tasks")]
    public async Task<IActionResult> CreateProjectTask(
        Guid projectId,
        [FromBody] CreateProjectTaskRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateProjectTaskCommand(
            projectId,
            request.Title,
            request.Description,
            request.CreatedByUserId,
            request.AssignedToUserId,
            request.DueDate,
            request.Priority);

        var result = await mediator.SendAsync(command, cancellationToken);

        return result.ToActionResult(this);
    }
}
