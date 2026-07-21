using DevFlow.Auth.Application.DTOs;
using DevFlow.Auth.Application.Register;
using DevFlow.BuildingBlocks.Messaging;

namespace DevFlow.Auth.Api.ServiceRegistrations;

public static class ServiceRegistration
{
    public static IServiceCollection AddMediatorServices(this IServiceCollection services)
        => services.AddTransient<IRequestHandler<RegisterUserCommand, RegisterUserDto>, RegisterUserCommandHandler>();
    
}
