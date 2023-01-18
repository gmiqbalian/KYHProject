using DBContextLibrary.Data;
using KYHProject.Enums;
using KYHProject.Models;
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
            if (!dbContext.ShapeResults.Any(s => s.Id == 1))
            {
                dbContext.ShapeResults.Add(new ShapeResult
                {
                    CreatedOn = DateTime.Now,
                    Type = EnumShapeType.Rectangle,
                    Base = 10,
                    Height = 15,
                    Area = 10 * 15,
                    Perimeter = 2 * 10 + 2 * 15
                });
            }
            if (!dbContext.ShapeResults.Any(s => s.Id == 1))
            {
                dbContext.ShapeResults.Add(new ShapeResult
                {
                    CreatedOn = DateTime.Now,
                    Type = EnumShapeType.Parallelogram,
                    Base = 12,
                    Height = 6,
                    ValueA = 8,
                    Area = 12 * 6,
                    Perimeter = 2 * 12 + 2 * 8
                });
            }
            if (!dbContext.ShapeResults.Any(s => s.Id == 1))
            {
                dbContext.ShapeResults.Add(new ShapeResult
                {
                    CreatedOn = DateTime.Now,
                    Type = EnumShapeType.Triangle,
                    Base = 34,
                    Height = 16,
                    ValueA = 23,
                    ValueC = 54,
                    Area = (16 * 34) / 2,
                    Perimeter = 23 + 34 + 54
                });
            }
            if (!dbContext.ShapeResults.Any(s => s.Id == 1))
            {
                dbContext.ShapeResults.Add(new ShapeResult
                {
                    CreatedOn = DateTime.Now,
                    Type = EnumShapeType.Rhombus,
                    Base = 17,
                    Height = 15,
                    Area = 17 * 15,
                    Perimeter = 4 * 17
                });
            }
        }
    }
}