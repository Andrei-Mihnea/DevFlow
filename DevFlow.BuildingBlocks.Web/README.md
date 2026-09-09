# DevFlow.BuildingBlocks.Web

Contains shared ASP.NET Core concerns that should not be duplicated in every API project.

`ResultExtensions.ToActionResult` converts `Result<T>` into consistent HTTP responses: validation failures become `400`, missing resources `404`, conflicts `409`, unauthorized failures `401`, and unexpected failures `500`.
