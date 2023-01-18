using ControllersLibrary;
using DBContextLibrary.Data;
using InputClassLibrary;
using KYHProject.ControllersLibrary;

namespace GameApp
{
    public class GameMenu
    {        
        private IGameController _gameController;
        public GameMenu(GameController gameController)
        {     
            _gameController = gameController;
        }
        public void ShowGameMenu()
        {
            while (true)
            {
                Console.Clear();
                Input.WriteMagenta("\nRock Paper Scissor");
                Console.WriteLine("---------------------");

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
