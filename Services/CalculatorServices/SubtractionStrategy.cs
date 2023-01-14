namespace KYHProject.Services
{
    public class SubtractionStrategy : ICalStrategy
    {
        public decimal Execute(decimal a, decimal b)
        {
            return a - b;
        }
    }
}
