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
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\\MSSQLLocalDB;Database=KYHProjectDb;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }
    }
}
