using KYHProject.App_Models;
using KYHProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InputClassLibrary;
using KYHProject.Enums;
using KYHProject.Models;

namespace KYHProject.Controllers
{
    public class ShapeController
    {
        private AppDbContext _dbContext;
        private ShapeFactory _shapeFactory;
               
        public ShapeController(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
            _shapeFactory = new ShapeFactory();
        }
        public Shape Create()
        {

            Console.Write("\nEnter Shape Type: ");
            Enum.TryParse(Console.ReadLine(), out EnumShapeType Type);
            var newShape = _shapeFactory.GetShape(Type);
            newShape.Type = Type;
            
            Console.Write("\nEnter shape base (b) value in cm: ");
            newShape.Base = Convert.ToDouble(Console.ReadLine());

            Console.Write("\nEnter shape height (h) value in cm: ");
            newShape.Height = Convert.ToDouble(Console.ReadLine());
            
            if(newShape.Type == EnumShapeType.Parallelogram ||
                newShape.Type == EnumShapeType.Triangle)
            {
                Console.Write("\nEnter value of side (a) value in cm: ");
                newShape.ValueA = Convert.ToDouble(Console.ReadLine());                
            }
            if (newShape.Type == EnumShapeType.Triangle) 
            {
                Console.Write("\nEnter value of side (c) value in cm: ");
                newShape.ValueC = Convert.ToDouble(Console.ReadLine());
            }

            _dbContext.Shapes.Add(newShape);
            _dbContext.SaveChanges();

            return newShape;
        }
    }
}
