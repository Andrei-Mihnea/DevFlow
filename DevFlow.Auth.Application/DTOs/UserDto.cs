namespace DevFlow.Auth.Application.DTOs;

public sealed record UserDto(
    Guid UserId,
    string Email,
    string FirstName,
    string LastName);
