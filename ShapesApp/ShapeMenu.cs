using DBContextLibrary.Data;
using InputClassLibrary;
using KYHProject;
using KYHProject.ControllersLibrary;

namespace ShapeApp
{
    public class ShapeMenu : IShapeMenu
    {        
        private readonly IController _shapeController;
        public ShapeMenu(IController shapeController)
        {     
            _shapeController = shapeController;
        }
        public void ShowShapeMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nShapes\n");

                Console.WriteLine("1. Calculate Area and Circumference of a Shape");
                Console.WriteLine("2. Edit current Shape calculations");
                Console.WriteLine("3. Show all Shape calculations");
                Console.WriteLine("4. Delete a Shape calculation");
                Console.WriteLine("0. Go to Main Menu");

                var sel = Input.GetSelFromRange(4);
                if (sel == 0) break;

                switch (sel)
                {
                    case 1:
                        _shapeController.Create();
                        break;
                    case 2:
                        _shapeController.Update();
                        break;
                    case 3:
                        _shapeController.Show();
                        Input.PressAnyKey();
                        break;
                    case 4:
                        _shapeController.Delete();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
