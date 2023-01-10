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
            //SeedShapes(dbContext);
            dbContext.SaveChanges();
        }
        public void SeedShapes(AppDbContext dbContext)
        {
            if (!dbContext.Shapes.Any(s => s.ShapeId == 1))
            {
                dbContext.Shapes.Add(new Shape
                { 
                    Type = EnumShapeType.Rectangle,
                    Base = 10,
                    Height = 10,
                });
            }
            if (!dbContext.Shapes.Any(s => s.ShapeId == 1))
            {
                dbContext.Shapes.Add(new Shape
                { 
                    Type = EnumShapeType.Parallelogram,
                    Base = 20,
                    Height = 10,
                    ValueA = 7
                });
            }
            if (!dbContext.Shapes.Any(s => s.ShapeId == 1))
            {
                dbContext.Shapes.Add(new Shape
                { 
                    Type = EnumShapeType.Triangle,
                    Base = 10,
                    Height = 15,
                    ValueA = 7,
                    ValueC = 7
                });
            }
            if (!dbContext.Shapes.Any(s => s.ShapeId == 1))
            {
                dbContext.Shapes.Add(new Shape
                { 
                    Type = EnumShapeType.Rhombus,
                    Base = 15,
                    Height = 15
                });
            }
        }
    }
}