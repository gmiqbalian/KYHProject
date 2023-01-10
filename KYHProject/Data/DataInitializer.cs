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
            if(!dbContext.Shapes.Any(s=> s.ShapeId == 1))
            {
                dbContext.Shapes.Add(new Shape 
                { Type = EnumShapeType.Rectangle });
            }
            if (!dbContext.Shapes.Any(s => s.ShapeId == 1))
            {
                dbContext.Shapes.Add(new Shape 
                { Type = EnumShapeType.Parallelogram });
            }
            if (!dbContext.Shapes.Any(s => s.ShapeId == 1))
            {
                dbContext.Shapes.Add(new Shape 
                { Type = EnumShapeType.Triangle });
            }
            if (!dbContext.Shapes.Any(s => s.ShapeId == 1))
            {
                dbContext.Shapes.Add(new Shape 
                { Type = EnumShapeType.Rhombus });
            }

        }
    }
}