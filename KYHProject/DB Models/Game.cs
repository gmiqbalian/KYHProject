using KYHProject.Enums;

namespace KYHProject.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public DateTime PlayedOn { get; set; }        
        public EnumGameResult Result { get; set; }
        public decimal WinAverage { get; set; }

    }
}
