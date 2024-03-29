﻿using DBContextLibrary.Data;
using InputClassLibrary;
using KYHProject.ControllersLibrary;

namespace Calculator
{
    public class CalculatorMenu
    {        
        private readonly IController _calculatorController;
        public CalculatorMenu(IController calculatorController)
        {     
            _calculatorController = calculatorController;            
        }
        public void ShowCalulatorMenu()
        {
            while (true)
            {
                Console.Clear();
                Input.WriteCyan("\nCalculation");
                Console.WriteLine("------------");

                Console.WriteLine("1. Make a calculation");
                Console.WriteLine("2. Edit previous calculation");
                Console.WriteLine("3. Show previous calculations");
                Console.WriteLine("4. Delete previous calculation");
                Console.WriteLine("0. Go to Main Menu");
                
                var sel = Input.GetSelFromRange(4);
                if (sel == 0) break;

                switch (sel)
                {
                    case 1:
                        _calculatorController.Create();
                        break;
                    case 2:
                        _calculatorController.Update();
                        break;
                    case 3:
                        _calculatorController.Show();
                        Input.PressAnyKey();
                        break;
                    case 4:
                        _calculatorController.Delete();
                        break;
                    default:
                        break;
                }
            }


        }

    }
}
