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
        private List<string> _choices;
        public GameController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _choices = new List<string> { "Rock", "Paper", "Scissors" };
        }
        public void Play()
        {
            var newGame = new Game();
            newGame.PlayedOn = DateTime.Now;

            ShowChoices();

            int userChoice = Input.GetSelFromRange(3) - 1;
            Console.WriteLine($"\nYou chose: {_choices[userChoice]}");

            var random = new Random();
            int computerChoice = random.Next(3);
            Console.WriteLine($"\nComputer chose: {_choices[computerChoice]}");

            newGame.Result = CheckResult(_choices, userChoice, computerChoice);

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
        private void ShowChoices()
        {
            int index = 1;
            Console.WriteLine("\nGame Choices\n");
            foreach (var choice in _choices)
            {
                Console.WriteLine($"{index}-{choice}");
                index++;
            }
        }
        private EnumGameResult CheckResult(List<string> choices, int userChoice, int computerChoice)
        {
            
            EnumGameResult gameResult;

            if (choices[userChoice] == choices[0] && choices[computerChoice] == choices[2])
                gameResult = EnumGameResult.Win;
            else if (choices[userChoice] == choices[2] && choices[computerChoice] == choices[1])
                gameResult = EnumGameResult.Win;
            else if (choices[userChoice] == choices[2] && choices[computerChoice] == choices[0])
                gameResult = EnumGameResult.Win;
            else if (choices[userChoice] == choices[computerChoice])
                gameResult = EnumGameResult.Draw;
            else
                gameResult = EnumGameResult.Loose;

            return gameResult;
        }
    }
}
