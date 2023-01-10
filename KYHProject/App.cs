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
                ResultController controller = null;

                switch (mainSel)
                {
                    case 1:
                        controller = new ResultController(dbContext);
                        subSel = Menu.ShapeMenu();
                        break;
                    case 2:
                        subSel = Menu.CalculatorMenu();
                        break;
                    case 3:
                        subSel = Menu.GameMenu();
                        break;
                    default:
                        break;
                }
                switch (subSel)
                {
                    case 1:
                        controller.Create();
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
