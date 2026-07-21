using DevFlow.Workspaces.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DevFlow.Workspaces.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWorkspacesDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("WorkspacesDb");

        services.AddDbContext<WorkspacesDbContext>(options =>
            options.UseOracle(connectionString));

        services.AddHealthChecks();

        return services;
    }
}
