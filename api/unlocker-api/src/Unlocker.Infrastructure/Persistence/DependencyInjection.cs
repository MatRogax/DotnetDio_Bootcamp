using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unlocker.Application.Persistence.Abstractions;
using Unlocker.Infrastructure.Persistence;
using Unlocker.Infrastructure.Persistence.Repositories;

namespace Unlocker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("PostgresConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException("⚠️ ConnectionString 'PostgresConnection' não foi definida.");

        Console.WriteLine($"🔗 Usando ConnectionString: {connectionString}");

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}