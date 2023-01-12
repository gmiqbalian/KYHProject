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
    public class ShapeController : IController
    {
        private AppDbContext _dbContext;
        private ShapeFactory _shapeFactory;
               
        public ShapeController(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
            _shapeFactory = new ShapeFactory();
        }
        public void Create()
        {            
            Console.Write("\nChoose Shape Type\n");
            
            Console.WriteLine("1. Rectangle");
            Console.WriteLine("2. Parallelogram");
            Console.WriteLine("3. Triangle");
            Console.WriteLine("4. Rhombus");
            Console.WriteLine("0. Go to Main Menu");
                                   
            var sel = Input.GetSelFromRange(4);
            
            var newShape = _shapeFactory.GetShape(sel);
            newShape.CreatedOn = DateTime.Now;

            newShape.Type = (EnumShapeType)sel;

            Console.Write("\nEnter shape base (b) value in cm: ");
            newShape.Base = Input.GetDecimal();
                        
            Console.Write("\nEnter shape height (h) value in cm: ");
            newShape.Height = Input.GetDecimal();
            
            if(newShape.Type == EnumShapeType.Parallelogram ||
                newShape.Type == EnumShapeType.Triangle)
            {
                Console.Write("\nEnter value of side (a) value in cm: ");
                newShape.ValueA = Input.GetDecimal();
            }
            if (newShape.Type == EnumShapeType.Triangle) 
            {
                Console.Write("\nEnter value of side (c) value in cm: ");
                newShape.ValueC = Input.GetDecimal();
            }

            _dbContext.Shapes.Add(newShape);
            _dbContext.SaveChanges();           
        }
        public void Show()
        {
            var shapesList = _dbContext.Shapes.
                ToList();

            var table = new ConsoleTable("Shape ID", "Date", "Type", "Area", "Perimeter");            
            foreach (var s in shapesList)
            {
                table.AddRow(
                    s.ShapeId, 
                    s.CreatedOn,
                    s.Type, 
                    s.Area, 
                    s.Perimeter);
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
            shapeToUpdate.Base = Input.GetDecimal();

            Console.Write("\nEnter shape height (h) value in cm: ");
            shapeToUpdate.Height = Input.GetDecimal();

            if (shapeToUpdate.Type == EnumShapeType.Parallelogram ||
                shapeToUpdate.Type == EnumShapeType.Triangle)
            {
                Console.Write("\nEnter value of side (a) value in cm: ");
                shapeToUpdate.ValueA = Input.GetDecimal();
            }
            if (shapeToUpdate.Type == EnumShapeType.Triangle)
            {
                Console.Write("\nEnter value of side (c) value in cm: ");
                shapeToUpdate.ValueC = Input.GetDecimal();
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
