using Microsoft.EntityFrameworkCore;

namespace KYHProject.Data
{
    public class DataInitializer
    {
        public void MigrateAndSeed(AppDbContext dbContext)
        {
            dbContext.Database.Migrate();
            SeedShapes(dbContext);
            dbContext.SaveChanges();
        }
        public void SeedShapes(AppDbContext dbContext)
        {
            
        }
    }
}