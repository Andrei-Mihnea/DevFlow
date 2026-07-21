using DevFlow.Auth.Application.Abstractions.Repositories;
using DevFlow.Auth.Infrastructure;
using DevFlow.Auth.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFlow.Auth.Api.ServiceRegistrations;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAuthDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("AuthDb");

        services.AddDbContext<AuthDbContext>(options =>
            options.UseOracle(connectionString))
                    .AddHealthChecks();

        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
