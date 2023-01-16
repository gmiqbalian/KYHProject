using KYHProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DBContextLibrary.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ShapeResult> ShapeResults { get; set; }
        public DbSet<CalculationResult> CalculationResults { get; set; }
        public DbSet<GameResult> GamesResults { get; set; } //change name to gameresults

        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=KYHProjectDb;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }
    }
}
