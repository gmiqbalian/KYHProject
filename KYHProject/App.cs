﻿using Calculator;
using ControllersLibrary;
using DBContextLibrary.Data;
using GameApp;
using InputClassLibrary;
using KYHProject.ControllersLibrary;
using ServicesLibrary.ShapeServices;
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
            MenuFactory menuFacotry = new MenuFactory(dbContext, mainController);


            while (true)
            {
                Console.Clear();                
                Console.WriteLine("\nMain Menu");
                Console.WriteLine("-----------");
                Input.WriteGreen("1. Shapes");
                Input.WriteCyan("2. Calculation");
                Input.WriteMagenta("3. Game");
                Console.WriteLine("0. Exit");
                
                var mainSel = Input.GetSelFromRange(3);
                if (mainSel == 0) return;

                switch (mainSel)
                {
                    case 1:        
                        menuFacotry.GetMenu("shape");                        
                        break;
                    case 2:
                        menuFacotry.GetMenu("calculator");                        
                        break;
                    case 3:
                        menuFacotry.GetMenu("game");                        
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
