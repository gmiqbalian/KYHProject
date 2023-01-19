using static System.Net.Mime.MediaTypeNames;

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
                    Input.WriteError("\nPlease enter a number: ");
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
                    Input.WriteError("\nPlease enter a number: ");
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
                Input.WriteError("\nPlease enter within given range: ");
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
                        Input.WriteError("\nPlease enter only \"y\" or \"n\": ");
                }
                catch (Exception)
                {
                    Input.WriteError("\nPlease enter only \"y\" or \"n\": ");
                }
            }
            return input;
        }        
        public static int CheckId(List<int> intList)
        {
            int id = 0;
            while (true)
            {
                Console.Write("\nEnter Id from the above table: ");
                id = Input.GetInt();
                if (intList.Contains(id))
                    break;
                else
                    Input.WriteError("\nId did not match.");
            }
            return id;
        }
        public static void PressAnyKey()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPress any key to continue...");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
        public static void WriteGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void WriteRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void WriteYellow(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void WriteWhite(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void WriteCyan(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void WriteMagenta(string text)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void WriteError(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}