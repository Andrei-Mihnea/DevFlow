using Application.Abstractions.Messaging;
using Application.Abstractions.Results;
using Application.DTOs;

namespace Application.Auth.Register;

public sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserDto>
{
    public Task<Result<RegisterUserDto>> HandleAsync(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var result = new RegisterUserDto(
            Guid.NewGuid(),
            request.Email,
            request.FirstName,
            request.LastName);

        return Task.FromResult(Result<RegisterUserDto>.Success(result));
    }
}
