using ControllersLibrary;
using DBContextLibrary.Data;
using InputClassLibrary;
using KYHProject.Enums;
using KYHProject.Models;

namespace KYHProject.ControllersLibrary
{
    public class GameController : IGameController
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
            while (true)
            {
                Console.Clear();
                var newGame = new GameResult();
                newGame.PlayedOn = DateTime.Now;

                ShowChoices();

                int userChoice = Input.GetSelFromRange(3) - 1;
                Console.WriteLine($"\nYou chose: {_choices[userChoice]}");

                var random = new Random();
                int computerChoice = random.Next(3);
                Console.WriteLine($"\nComputer chose: {_choices[computerChoice]}");

                newGame.Result = CheckResult(_choices, userChoice, computerChoice);

                string message = $"\nGame Result: {newGame.Result}!!!";
                Input.WriteYellow(message);

                _dbContext.GamesResults.Add(newGame);
                _dbContext.SaveChanges();

                newGame.WinAverage = GetStats();

                Console.Write("\nPlay again? y/n: ");
                var sel = Input.GetYesNo();

                if (sel == 'n') break;

            }

            var text = $"\nYour Win Percentage is: {GetStats().ToString("##.##")} %";
            Input.WriteGreen(text);

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
            else if (choices[userChoice] == choices[1] && choices[computerChoice] == choices[0])
                gameResult = EnumGameResult.Win;
            else if (choices[userChoice] == choices[computerChoice])
                gameResult = EnumGameResult.Draw;
            else
                gameResult = EnumGameResult.Loose;

            return gameResult;
        }
        private decimal GetStats()
        {
            var totalWon = _dbContext.GamesResults.
               Where(g => (int)g.Result == 1).
               Count();
            var totalPlayed = _dbContext.GamesResults.
                Select(g => g.Result).
                Count();

            return (totalWon / (decimal)totalPlayed) * 100;
        }
    }
}
