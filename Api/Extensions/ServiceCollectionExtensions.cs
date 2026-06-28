using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("OracleDb");
        services.AddDbContext<AppDbContext>(options => 
            options.UseOracle(connectionString));
        
        return services;
    }
}