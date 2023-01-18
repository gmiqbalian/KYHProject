using Calculator;
using ControllersLibrary;
using DBContextLibrary.Data;
using GameApp;
using KYHProject.ControllersLibrary;
using ShapeApp;

namespace KYHProject
{
    public class App
    {
        public void Run()
        {
            var builder = new Builder();
            var dbContext = builder.BuildApp();
            ControllerFactory mainController = new ControllerFactory(dbContext);
            IController controller = null;

            while (true)
            {
                var mainSel = Menu.MainMenu();
                if (mainSel == 0) return;

                switch (mainSel)
                {
                    case 1:
                        controller = mainController.GetController("shape");
                        var shapeApp = new ShapesMenu(dbContext, controller);
                        shapeApp.ShowShapeMenu();
                        break;
                    case 2:
                        controller = mainController.GetController("calculator");
                        var calculatorApp = new CalculatorMenu(dbContext, controller);
                        calculatorApp.ShowCalulatorMenu();
                        break;
                    case 3:
                        var gameApp = new GameMenu(dbContext);
                        gameApp.ShowGameMenu();
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
