namespace Application.DTOs;

public sealed record RegisterUserDto(
    Guid UserId,
    string Email,
    string FirstName,
    string LastName);