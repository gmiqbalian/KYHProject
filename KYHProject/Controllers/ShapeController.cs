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
using Microsoft.EntityFrameworkCore;
using ConsoleTables;

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
        public void Show()
        {
            var shapesList = _dbContext.Results.
                Include(r => r.Shape).
                ToList();

            var table = new ConsoleTable("Result ID", "Date", "Shape ID", "Type", "Area", "Perimeter");            
            foreach (var r in shapesList)
            {
                table.AddRow(r.ResultId, 
                    r.CreatedOn.ToShortDateString(), 
                    r.Shape.ShapeId, 
                    r.Shape.Type, 
                    r.Shape.Area, 
                    r.Shape.Perimeter);
            }

            Console.WriteLine(table);
        }
        public void Update()
        {
            Show();

            Console.Write("\nEnter shape Id to update: ");
            var shapeIdToUpdate = Input.GetInt();

            var shapeToUpdate = _dbContext.Shapes.
                First(s => s.ShapeId == shapeIdToUpdate);

            Console.WriteLine("\nEnter new Shape type: ");
            Enum.TryParse(Console.ReadLine(), out EnumShapeType type);

            shapeToUpdate.Type = type;

            Console.Write("\nEnter shape base (b) value in cm: ");
            shapeToUpdate.Base = Convert.ToDouble(Console.ReadLine());

            Console.Write("\nEnter shape height (h) value in cm: ");
            shapeToUpdate.Height = Convert.ToDouble(Console.ReadLine());

            if (shapeToUpdate.Type == EnumShapeType.Parallelogram ||
                shapeToUpdate.Type == EnumShapeType.Triangle)
            {
                Console.Write("\nEnter value of side (a) value in cm: ");
                shapeToUpdate.ValueA = Convert.ToDouble(Console.ReadLine());
            }
            if (shapeToUpdate.Type == EnumShapeType.Triangle)
            {
                Console.Write("\nEnter value of side (c) value in cm: ");
                shapeToUpdate.ValueC = Convert.ToDouble(Console.ReadLine());
            }
        }
        public void Delete()
        {
            Console.Write("\nEnter shape Id to delete: ");
            var shapeIdToDelete = Input.GetInt();

            var shapeToDelete = _dbContext.Shapes.
                First(s => s.ShapeId == shapeIdToDelete);

            _dbContext.Shapes.Remove(shapeToDelete);
            _dbContext.SaveChanges();
        }
    }
}
