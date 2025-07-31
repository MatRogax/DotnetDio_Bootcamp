using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Unlocker.Infrastructure.Persistence;

namespace Unlocker.Infrastructure;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var connectionString = "Host=localhost;Port=5432;Database=unlockerdb;Username=postgres;Password=postgres";

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new AppDbContext(optionsBuilder.Options);
    }
}