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

        public static int GameMenu()
        {
            Console.Clear();
            Console.WriteLine("\nRock Paper Scissor\n");

            Console.WriteLine("1. Play the Game");
            Console.WriteLine("2. Show previous statistics");
            Console.WriteLine("0. Go to Main Menu");

            return Input.GetSelFromRange(2);
        }

    }
}
