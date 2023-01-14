namespace KYHProject.Services
{
    public class MultiplicationStrategy : ICalStrategy
    {
        public decimal Execute(decimal a, decimal b)
        {
            return a * b;
        }
    }
}
