using DevFlow.Projects.Application.Abstractions.Repositories;
using DevFlow.Projects.Infrastructure;
using DevFlow.Projects.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFlow.Projects.Api.ServiceRegistrations;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddProjectsDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ProjectsDb");

        services.AddDbContext<ProjectsDbContext>(options =>
            options.UseOracle(connectionString))
            .AddHealthChecks();

        services.AddScoped<IProjectRepository, ProjectRepository>();

        return services;
    }
}
