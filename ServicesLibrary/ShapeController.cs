using InputClassLibrary;
using KYHProject.Enums;
using ConsoleTables;
using KYHProject.Models;
using ServicesLibrary.ShapeServices;
using DBContextLibrary.Data;
using System.Reflection.Metadata.Ecma335;

namespace KYHProject.ControllersLibrary
{
    public class ShapeController : IController
    {
        private readonly AppDbContext _dbContext;
        private ShapeResult _shape;
        
        public ShapeController(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
            
        }
        public void Create()
        {            
            _shape = new ShapeResult();
            
            GetInputValues();
            CalculateAreaPerimeter();

            _dbContext.ShapeResults.Add(_shape);
            _dbContext.SaveChanges();

            Input.WriteYellow($"\nArea = {_shape.Area}cm2 and Perimeter = {_shape.Perimeter}cm2");
            Input.PressAnyKey();
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
            
            var idList = _dbContext.
                ShapeResults.
                Select(r => r.Id).ToList();

            var shapeIdToUpdate = Input.CheckId(idList);
            
            _shape = _dbContext.
                ShapeResults.
                First(s => s.Id == shapeIdToUpdate);

            GetInputValues();
            CalculateAreaPerimeter();

            _dbContext.SaveChanges();
            Input.WriteYellow($"\nNew Area = {_shape.Area}cm2 and New Perimeter = {_shape.Perimeter}cm2");
            Input.WriteGreen("\nSuccesfully updated the choosen Shape!");
            Input.PressAnyKey();
        }
        public void Delete()
        {            
            Show();

            var idList = _dbContext.
                ShapeResults.
                Select(r => r.Id).ToList();

            var shapeIdToDelete = Input.CheckId(idList);

            var shapeToDelete = _dbContext.ShapeResults.
                First(s => s.Id == shapeIdToDelete);

            _dbContext.ShapeResults.Remove(shapeToDelete);
            _dbContext.SaveChanges();
            Input.WriteRed("\nSuccesfully deleted the Shape!");
            Input.PressAnyKey();
        }
        private static int ShowShapeTypes()
        {
            Console.Write("\nChoose Shape Type\n\n");

            Console.WriteLine("1. Rectangle");
            Console.WriteLine("2. Parallelogram");
            Console.WriteLine("3. Triangle");
            Console.WriteLine("4. Rhombus");
                        
            return Input.GetSelFromRange(4);           
        }
        private void GetInputValues()
        {
            var sel = ShowShapeTypes();

            _shape.CreatedOn = DateTime.Now;
            _shape.Type = (EnumShapeType)sel;

            Console.Write("\nEnter shape base (b) value in cm: ");
            _shape.Base = Input.GetDecimal();

            Console.Write("\nEnter shape height (h) value in cm: ");
            _shape.Height = Input.GetDecimal();

            if (_shape.Type == EnumShapeType.Parallelogram ||
                _shape.Type == EnumShapeType.Triangle)
            {
                Console.Write("\nEnter value of side (a) in cm: ");
                _shape.ValueA = Input.GetDecimal();
            }
            if (_shape.Type == EnumShapeType.Triangle)
            {
                Console.Write("\nEnter value of side (c) in cm: ");
                _shape.ValueC = Input.GetDecimal();
            }
        }        
        private void CalculateAreaPerimeter()
        {
            var shapeStrategy = new ShapeStrategy();

            switch (_shape.Type)
            {
                case EnumShapeType.Rectangle:
                    shapeStrategy.
                        SetStrategy(new RectangleStrategy());
                    break;
                case EnumShapeType.Parallelogram:
                    shapeStrategy.
                        SetStrategy(new ParallelogramStrategy());
                    break;
                case EnumShapeType.Triangle:
                    shapeStrategy.
                        SetStrategy(new TriangleStrategy());
                    break;
                case EnumShapeType.Rhombus:
                    shapeStrategy.
                        SetStrategy(new RhombusStrategy());
                    break;
                default:
                    break;
            }
            
            shapeStrategy.ExecuteStrategy(_shape);
        }
    }
}
