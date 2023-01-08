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
    }
}