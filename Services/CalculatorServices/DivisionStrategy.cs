namespace KYHProject.Services
{
    public class DivisionStrategy : ICalStrategy
    {
        public decimal Execute(decimal a, decimal b)
        {
            return a / b;
        }
    }
}
