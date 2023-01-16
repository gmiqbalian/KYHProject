using Calculator;
using DBContextLibrary.Data;
using GameApp;
using ShapeApp;

namespace KYHProject
{
    public class App
    {
        public void Run()
        {
            var builder = new Builder();
            var dbContext = builder.BuildApp();

            while (true)
            {
                var mainSel = Menu.MainMenu();
                if (mainSel == 0) return;

                switch (mainSel)
                {
                    case 1:
                        var shapeApp = new ShapesMenu(dbContext);
                        shapeApp.ShowShapeMenu();
                        break;
                    case 2:
                        var calculatorApp = new CalculatorMenu(dbContext);
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
