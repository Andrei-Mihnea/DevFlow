using Application.Abstractions.Messaging;
using Application.DTOs;

namespace Application.Auth.Register;

public sealed record RegisterUserCommand(
    string Email,
    string Password,
    string ReTypedPassword,
    string FirstName,
    string LastName) : IRequest<RegisterUserDto>;
