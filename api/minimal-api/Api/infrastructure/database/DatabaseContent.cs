using Microsoft.EntityFrameworkCore;
using minimal_api.domain.entities;

namespace minimal_api.domain.infrastructure.Database
{
    public class DatabaseContent : DbContext
    {
        private readonly IConfiguration _configurationAppSettings;

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Admin>().HasData(
                new Admin{
                    Id = 1, Email = "adm@teste.com",
                    Password = "123456",
                    Profile = "admin",
                }
            );
        }

        public DatabaseContent(IConfiguration configurationAppSettings)
        {
            _configurationAppSettings = configurationAppSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        var connection = _configurationAppSettings.GetConnectionString("PostgresConnection")?.ToString();

        if (string.IsNullOrEmpty(connection))
        {
            connection = "Host=db;Port=5432;Database=postgres;Username=postgres;Password=postgres";
        }

        var retries = 5;
        while (retries > 0)
        {
            try
            {
                optionsBuilder.UseNpgsql(connection);
                break; 
            }
            catch (Exception ex)
            {
                retries--;
                if (retries == 0)
                {
                    throw new Exception("Unable to connect to the database after multiple attempts", ex);
                }
                // Wait a bit before retrying
                System.Threading.Thread.Sleep(5000);
            }
        }
    }
}

    }
}
