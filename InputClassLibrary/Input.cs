using Microsoft.Identity.Client;

namespace InputClassLibrary
{
    public static class Input
    {
        public static int GetInt()
        {
            int input;

            while (true)
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    break;                    
                }
                catch (FormatException)
                {                    
                    Console.Write("\nPlease enter a number: ");
                }
            }
            return input;
        }
        public static decimal GetDecimal()
        {
            decimal input;
            while (true)
            {
                try
                {
                    input = Convert.ToDecimal(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.Write("\nPlease enter a number: ");
                }
            }
            return input;
        }
        public static int GetSelFromRange(int maxRange)
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
        public static char GetYesNo()
        {
            char input;
            while (true)
            {
                try
                {
                    input = Convert.ToChar(Console.ReadLine());

                    if (char.IsLetter(input) && (input == 'y' || input == 'n'))
                        break;
                    else
                        Console.Write("\nPlease enter only \"y\" or \"n\": ");
                }
                catch (Exception)
                {                    
                    Console.Write("\nPlease enter only \"y\" or \"n\": ");
                }
            }
            return input;
        }        
        public static void PressAnyKey()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPress any key to continue...");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
        public static void WriteGreen(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(input);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void WriteRed(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(input);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void WriteYellow(string input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(input);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}