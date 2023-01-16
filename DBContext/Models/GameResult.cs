using KYHProject.Enums;

namespace KYHProject.Models
{
    public class GameResult
    {
        public int Id { get; set; }
        public DateTime PlayedOn { get; set; }
        public EnumGameResult Result { get; set; }
        public decimal WinAverage { get; set; }

    }
}
