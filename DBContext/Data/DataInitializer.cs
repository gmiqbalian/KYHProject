using DBContextLibrary.Data;
using KYHProject.Enums;
using KYHProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace KYHProject.Data
{
    public class DataInitializer
    {
        public void MigrateAndSeed(AppDbContext dbContext)
        {
            dbContext.Database.Migrate();
            //SeedShapes(dbContext);
            dbContext.SaveChanges();
        }
        public void SeedShapes(AppDbContext dbContext)
        {
            if (!dbContext.ShapeResults.Any(s => s.Id == 1))
            {
                dbContext.ShapeResults.Add(new ShapeResult
                { 
                    CreatedOn = DateTime.Now,
                    Base = 10,
                    Height = 15,                    
                    Type = EnumShapeType.Rectangle,
                    Area = 10 * 15,
                    Perimeter = 2 * 10 + 2 * 15,
                });
            }
            if (!dbContext.ShapeResults.Any(s => s.Id == 1))
            {
                dbContext.ShapeResults.Add(new ShapeResult
                { 
                    Type = EnumShapeType.Parallelogram,
                    Base = 20,
                    Height = 10,
                    ValueA = 7
                });
            }
            if (!dbContext.ShapeResults.Any(s => s.Id == 1))
            {
                dbContext.ShapeResults.Add(new ShapeResult
                { 
                    Type = EnumShapeType.Triangle,
                    Base = 10,
                    Height = 15,
                    ValueA = 7,
                    ValueC = 7
                });
            }
            if (!dbContext.ShapeResults.Any(s => s.Id == 1))
            {
                dbContext.ShapeResults.Add(new ShapeResult
                { 
                    Type = EnumShapeType.Rhombus,
                    Base = 15,
                    Height = 15
                });
            }
        }
    }
}