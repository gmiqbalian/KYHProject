using KYHProject.Controllers;
using KYHProject.Data;
using KYHProject.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                int subSel = 0;
                IController controller = null;

                switch (mainSel)
                {
                    case 1:
                        controller = new ShapeController(dbContext);
                        subSel = Menu.ShapeMenu();
                        break;
                    case 2:
                        controller = new CalculatorController(dbContext);
                        subSel = Menu.CalculatorMenu();
                        break;
                    case 3:
                        //controller = new GameController(dbContext);
                        //subSel = Menu.GameMenu();
                        break;
                    default:
                        break;
                }
                switch (subSel)
                {
                    case 1:
                        controller.Create();
                        break;
                    case 2:
                        controller.Update();
                        break;
                    case 3:
                        controller.Show();
                        System.Threading.Thread.Sleep(3000);
                        break;
                    case 4:
                        controller.Delete();
                        break;
                    case 0:
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
