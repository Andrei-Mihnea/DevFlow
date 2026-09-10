using DevFlow.Auth.Application.Abstractions.Repositories;
using DevFlow.Auth.Application.DTOs;
using DevFlow.Auth.Domain.Users;
using DevFlow.BuildingBlocks.Messaging;
using DevFlow.BuildingBlocks.Results;

namespace DevFlow.Auth.Application.Register;

public sealed class RegisterUserCommandHandler(IUserRepository userRepository)
    : IRequestHandler<RegisterUserCommand, RegisterUserDto>
{
    public async Task<Result<RegisterUserDto>> HandleAsync(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var emailExists = await userRepository.ExistsByEmailAsync(request.Email, cancellationToken);

        if (emailExists)
        {
            return Result<RegisterUserDto>.Failure(
                new Error(
                    "Users.EmailAlreadyExists",
                    "A user with this email already exists.",
                    ErrorType.Conflict));
        }

        var user = new User(
            request.Email,
            request.Password,
            request.FirstName,
            request.LastName);

        userRepository.Add(user);
        await userRepository.SaveChangesAsync(cancellationToken);

        var result = new RegisterUserDto(
            user.Id,
            user.Email,
            user.FirstName,
            user.LastName);

        return Result<RegisterUserDto>.Success(result);
    }
}
