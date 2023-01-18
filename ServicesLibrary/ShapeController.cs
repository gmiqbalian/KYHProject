using ConsoleTables;
using DBContextLibrary.Data;
using InputClassLibrary;
using KYHProject.Enums;
using KYHProject.Models;
using ServicesLibrary.ShapeServices;

namespace KYHProject.ControllersLibrary
{
    public class ShapeController : IController
    {
        private readonly AppDbContext _dbContext;
        private readonly ShapeServices _shapeServices;
        private ShapeResult _shape;

        public ShapeController(AppDbContext dbContext, ShapeServices shapeServices)
        {
            _dbContext = dbContext;
            _shapeServices = shapeServices;
        }
        public void Create()
        {
            Console.Clear();

            _shape = new ShapeResult();
            GetInputValues();
            _shapeServices.SetStrategy(_shape);
            _shapeServices.ExecuteStrategy(_shape);

            _dbContext.ShapeResults.Add(_shape);
            _dbContext.SaveChanges();

            Input.WriteYellow($"\n{_shape.Type} Area = {_shape.Area}cm2");
            Input.WriteYellow($"\n{_shape.Type} Perimeter = {_shape.Perimeter}cm");

            Input.PressAnyKey();
        }
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("\nPrevious Shape Calculations");
            var shapesList = GetList();
            if (shapesList == null)
                return;

            var table = new ConsoleTable(
                "Shape ID",
                "Date",
                "Type",
                "Area (cm2)",
                "Perimeter (cm)");
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
            var shapesList = GetList();
            if (shapesList == null)
                return;

            Show();

            var idList = _dbContext.
                ShapeResults.
                Select(r => r.Id).ToList();

            var shapeIdToUpdate = Input.CheckId(idList);

            _shape = _dbContext.
                ShapeResults.
                First(s => s.Id == shapeIdToUpdate);

            GetInputValues();
            _shapeServices.SetStrategy(_shape);
            _shapeServices.ExecuteStrategy(_shape);

            _dbContext.SaveChanges();

            Input.WriteYellow($"\nNew {_shape.Type} Area = {_shape.Area}cm2");
            Input.WriteYellow($"\nNew {_shape.Type} Perimeter = {_shape.Perimeter}cm");
            Input.WriteGreen("\nSuccesfully updated the choosen Shape!");
            Input.PressAnyKey();
        }
        public void Delete()
        {
            var shapesList = GetList();
            if (shapesList == null)
                return;

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
        private List<ShapeResult> GetList()
        {
            var list = _dbContext.
                ShapeResults.
                ToList();

            if (list.Count() == 0)
            {
                Input.WriteYellow("\nThere is no record to show.");
                return null;
            }

            return list;
        }
    }
}
