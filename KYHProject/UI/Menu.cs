using InputClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHProject.UI
{
    public static class Menu
    {
        public static int MainMenu()            
        {
            Console.Clear();
            Console.WriteLine("\nMain Menu\n");

            Console.WriteLine("1. Shapes");
            Console.WriteLine("2. Calculator");
            Console.WriteLine("3. Game");
            Console.WriteLine("0. Exit");

            return GetMenuSel(3);
        }
        public static int ShapeMenu()
        {
            Console.Clear();
            Console.WriteLine("\nShapes\n");

            Console.WriteLine("1. Calculate Area and Circumference of a Shape");
            Console.WriteLine("2. Edit current Shape calculations");
            Console.WriteLine("3. Show all Shape calculations");
            Console.WriteLine("4. Delete a Shape calculation");
            Console.WriteLine("0. Go to Main Menu");

            return GetMenuSel(4);
        }
        public static int CalculatorMenu()
        {
            Console.Clear();
            Console.WriteLine("\nCalculator\n");

            Console.WriteLine("1. Make a calculation");
            Console.WriteLine("2. Edit previous calculation");
            Console.WriteLine("3. Show previous calculations");
            Console.WriteLine("4. Delete previous calculation");
            Console.WriteLine("0. Go to Main Menu");

            return GetMenuSel(4);
        }
        public static int GameMenu()
        {
            Console.Clear();
            Console.WriteLine("\nRock Paper Scissor\n");

            Console.WriteLine("1. Play the Game");
            Console.WriteLine("2. Show previous statistics");
            Console.WriteLine("0. Go to Main Menu");

            return GetMenuSel(2);
        }
        private static int GetMenuSel(int maxRange)
        {
            Console.Write("\nEnter from given options: ");            
            var sel = Input.GetInt();

            while (sel < 0 || sel > maxRange)
            {
                Console.Write("\nPlease enter within given range: ");
                sel = Input.GetInt();
            }
            return sel;           
        }
    }
}
