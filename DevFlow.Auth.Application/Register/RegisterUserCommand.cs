using DevFlow.Auth.Application.DTOs;
using DevFlow.BuildingBlocks.Messaging;

namespace DevFlow.Auth.Application.Register;

public sealed record RegisterUserCommand(
    string Email,
    string Password,
    string ReTypedPassword,
    string FirstName,
    string LastName) : IRequest<RegisterUserDto>;
