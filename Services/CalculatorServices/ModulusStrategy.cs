namespace KYHProject.Services
{
    public class ModulusStrategy : ICalStrategy
    {
        public decimal Execute(decimal a, decimal b)
        {
            return a % b;
        }
    }
}
