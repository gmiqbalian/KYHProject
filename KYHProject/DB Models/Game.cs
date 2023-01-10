using KYHProject.Enums;

namespace KYHProject.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public EnumGameResult Result { get; set; }
        public List<Result> Results { get; set; } = new List<Result>();

    }
}
