using InputClassLibrary;

namespace KYHProject
{
    public static class Menu
    {
        public static int MainMenu()
        {
            Console.Clear();
            Console.WriteLine("\nMain Menu\n");

            Console.WriteLine("1. Shapes");
            Console.WriteLine("2. Calculation");
            Console.WriteLine("3. Game");
            Console.WriteLine("0. Exit");

            return Input.GetSelFromRange(3);
        }
    }
}
