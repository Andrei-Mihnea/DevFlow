using Application.Abstractions.Behaviours;
using Application.Abstractions.Messaging;
using Application.Abstractions.Validations;
using Application.Auth.Register;
using Application.DTOs;
using Application.Messaging;

namespace Api.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection MediatorServices(this IServiceCollection services)
    {
        services.AddTransient<IMediator, Mediator>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        services.AddTransient<IRequestHandler<RegisterUserCommand, RegisterUserDto>, RegisterUserCommandHandler>();
        services.AddTransient<IValidator<RegisterUserCommand>, RegisterUserCommandValidator>();

        return services;
    }
}
