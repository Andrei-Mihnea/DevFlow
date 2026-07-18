using Application.Abstractions.Messaging;
using Application.Messaging;

namespace Api.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection MediatorServices(this IServiceCollection services)
    {
        services.AddTransient<IMediator, Mediator>();

        return services;
    }
}