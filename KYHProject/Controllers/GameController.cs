using InputClassLibrary;
using KYHProject.Data;
using KYHProject.Enums;
using KYHProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHProject.Controllers
{
    public class GameController
    {
        private AppDbContext _dbContext;
        public GameController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Play()
        {
            var newGame = new Game();
            newGame.PlayedOn = DateTime.Now;

            var random = new Random();

            var choices = new List<string> { "Rock", "Paper", "Scissors" };
            int index = 1;
            Console.WriteLine("\nGame Choices\n");
            foreach (var choice in choices)
            {
                Console.WriteLine($"{index}-{choice}");
                index++;
            }

            int userChoice = Input.GetSelFromRange(3) - 1;
            Console.WriteLine($"\nYou choose: {choices[userChoice]}");

            int computerChoice = random.Next(3);
            Console.WriteLine($"\nComputer choose: {choices[computerChoice]}");

            if (choices[userChoice] == choices[0] && choices[computerChoice] == choices[2])
                newGame.Result = EnumGameResult.Win;
            else if (choices[userChoice] == choices[2] && choices[computerChoice] == choices[1])
                newGame.Result = EnumGameResult.Win;
            else if (choices[userChoice] == choices[2] && choices[computerChoice] == choices[0])
                newGame.Result = EnumGameResult.Win;
            else if (choices[userChoice] == choices[computerChoice])
                newGame.Result = EnumGameResult.Draw;
            else
                newGame.Result = EnumGameResult.Loose;

            Console.WriteLine($"\nGame Result: {newGame.Result}");
            
            _dbContext.Games.Add(newGame);
            
            var totalWon = _dbContext.Games.
                Where(g => (int)g.Result == 1).
                Count();
            var totalPlayed = _dbContext.Games.
                Select(g => g.Result).
                Count();

            newGame.WinAverage = totalWon / totalPlayed;

            Console.WriteLine($"\nWin Percentage: {newGame.WinAverage} %");
                        
            System.Threading.Thread.Sleep(3000);

            _dbContext.SaveChanges();
        }     
    }
}
