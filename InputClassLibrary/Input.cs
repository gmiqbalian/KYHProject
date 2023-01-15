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
                catch (FormatException e)
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
                catch (FormatException e)
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

        public static char GetChar()  //FIXXXXXXXXXXXXXX THIS
        {            
            string stringInput = Console.ReadLine();
            char charInput;
            while (true)
            {
                try
                {
                    if (IsLetter(stringInput))
                    {
                        charInput = Convert.ToChar(stringInput);
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.Write("\nPlease enter only \"y\" or \"n\": ");
                }                
            }
            return charInput;
        }                
        public static bool IsLetter(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                foreach (var c in input.ToCharArray())
                {
                    if (char.IsDigit(c))
                        return false;
                }
            }
            return true;
        }
        public static void PressAnyKey()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPress any key to continue...");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
    }
}