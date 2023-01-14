using KYHProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DBContextLibrary.Data
{
    public class Builder
    {
        public AppDbContext BuildApp()
        {
            var configBuilder = new ConfigurationBuilder().
                AddJsonFile($"appsettings.json", true, true);
            var config = configBuilder.Build();

            var options = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);

            using (var dbContext = new AppDbContext(options.Options))
            {
                var dataInitializer = new DataInitializer();
                dataInitializer.MigrateAndSeed(dbContext);
            }

            var dbContextWithOptions = new AppDbContext(options.Options);
            return dbContextWithOptions;
        }
    }
}

