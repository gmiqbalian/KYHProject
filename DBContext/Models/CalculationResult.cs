namespace KYHProject.Models
{
    public class CalculationResult
    {
        public int Id {get; set;}
        public DateTime CreatedOn { get; set;}
        public decimal a { get; set; }
        public decimal b { get; set; }
        public char Operator { get; set; }
        public decimal Result { get; set; }        
    }

}

