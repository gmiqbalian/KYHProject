using InputClassLibrary;
using KYHProject.Enums;
using ConsoleTables;
using KYHProject.Models;
using ServicesLibrary.ShapeFactory;
using DBContextLibrary.Data;

namespace KYHProject.ControllersLibrary
{
    public class ShapeController : IController
    {
        private readonly AppDbContext _dbContext;
        private readonly ShapeFactory _shapeCreator;
        private Shape _shape;
        
        public ShapeController(AppDbContext dbContext) 
        {
            _dbContext = dbContext;            
            _shapeCreator = new ShapeCreator();
        }
        public void Create()
        {            
            GetShape();

            _dbContext.ShapeResults.Add(new ShapeResult
            {
                CreatedOn = DateTime.Now,
                Type = _shape.Type,
                Height = _shape.h,
                Base = _shape.b,
                ValueA = _shape.a,
                ValueC = _shape.c,
                Area = _shape.GetArea(),
                Perimeter = _shape.GetPerimeter()
            });
                        
            _dbContext.SaveChanges();
        }

        public void Show()
        {
            var shapesList = _dbContext.ShapeResults.
                ToList();

            var table = new ConsoleTable(
                "Shape ID", 
                "Date", 
                "Type", 
                "Area (cm2)", 
                "Perimeter (cm2)");            
            foreach (var s in shapesList)
            {
                table.AddRow(
                    s.Id, 
                    s.CreatedOn.ToShortDateString(),
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

            var shapeToUpdate = _dbContext.ShapeResults.
                First(s => s.Id == shapeIdToUpdate);
            
            GetShape();            

            shapeToUpdate.Type = _shape.Type;
            shapeToUpdate.Base = _shape.b;
            shapeToUpdate.Height = _shape.h;
            shapeToUpdate.ValueA = _shape.a;
            shapeToUpdate.ValueC = _shape.c;
            shapeToUpdate.Area = _shape.GetArea();
            shapeToUpdate.Perimeter = _shape.GetPerimeter();
        }
        public void Delete()
        {
            Show();

            Console.Write("\nEnter shape Id to delete: ");
            var shapeIdToDelete = Input.GetInt();

            var shapeToDelete = _dbContext.ShapeResults.
                First(s => s.Id == shapeIdToDelete);

            _dbContext.ShapeResults.Remove(shapeToDelete);
            _dbContext.SaveChanges();
        }
        private static int ShowShapeTypes()
        {
            Console.Write("\nChoose Shape Type\n\n");

            Console.WriteLine("1. Rectangle");
            Console.WriteLine("2. Parallelogram");
            Console.WriteLine("3. Triangle");
            Console.WriteLine("4. Rhombus");
                        
            return Input.GetSelFromRange(3);           
        }
        private void GetShape()
        {
            _shape = new Shape();

            var sel = ShowShapeTypes();
            _shape = _shapeCreator.GetShape(sel);
            _shape.Type = (EnumShapeType)sel;

            Console.Write("\nEnter shape base (b) value in cm: ");
            _shape.b = Input.GetDecimal();

            Console.Write("\nEnter shape height (h) value in cm: ");
            _shape.h = Input.GetDecimal();

            if (_shape.Type == EnumShapeType.Parallelogram ||
                _shape.Type == EnumShapeType.Triangle)
            {
                Console.Write("\nEnter value of side (a) in cm: ");
                _shape.a = Input.GetDecimal();
            }
            if (_shape.Type == EnumShapeType.Triangle)
            {
                Console.Write("\nEnter value of side (c) in cm: ");
                _shape.c = Input.GetDecimal();
            }
        }
    }
}
