namespace KYHProject.Services
{
    public class AdditionStrategy : ICalStrategy
    {        
        public decimal Execute(decimal a, decimal b)
        {
            return a + b;
        }
    }
}
