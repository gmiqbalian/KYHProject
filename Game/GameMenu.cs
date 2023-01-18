using ControllersLibrary;
using DBContextLibrary.Data;
using InputClassLibrary;
using KYHProject.ControllersLibrary;

namespace GameApp
{
    public class GameMenu
    {
        private readonly AppDbContext _dbContext;
        private IGameController _gameController;
        public GameMenu(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _gameController = new GameController(_dbContext);
        }
        public void ShowGameMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nRock Paper Scissor\n");

                Console.WriteLine("1. Play the Game");
                Console.WriteLine("0. Main Menu");

                var sel = Input.GetSelFromRange(2);
                if (sel == 0) break;

                switch (sel)
                {
                    case 1:
                        _gameController.Play();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
