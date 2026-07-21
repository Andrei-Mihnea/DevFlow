using DevFlow.Auth.Application.Register;
using DevFlow.Auth.Application.Validations;
using DevFlow.BuildingBlocks.Validation;

namespace DevFlow.Auth.Api.ServiceRegistrations;

public static class ValidationRegistration
{
    public static IServiceCollection AddValidation(this IServiceCollection services)
        => services.AddTransient<IValidator<RegisterUserCommand>, RegisterUserCommandValidator>();
}
