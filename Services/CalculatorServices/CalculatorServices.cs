using KYHProject.Models;

namespace KYHProject.Services
{
    public class CalculatorServices
    {
        private ICalStrategy _calStrategy;
        public void SetStrategy(ICalStrategy calStrategy)
        {
            _calStrategy = calStrategy;
        }
        public decimal ExecuteStrategy(decimal a, decimal b)
        {
            return _calStrategy.Execute(a, b);
        }       
    }
}
