using DBContextLibrary.Data;
using InputClassLibrary;
using KYHProject.ControllersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    public class GameMenu
    {
        private readonly AppDbContext _dbContext;
        private GameController _gameController;
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
