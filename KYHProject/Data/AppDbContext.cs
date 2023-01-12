using KYHProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHProject.Data
{
    public class AppDbContext: DbContext
    {   
        public DbSet<Shape> Shapes { get; set; }
        public DbSet<Calculation> Calculators { get; set; }
        public DbSet<Game> Games { get; set; }

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
