using KYHProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.CalculatorServices
{
    public class SquareRootStrategy : ICalStrategy
    {
        public decimal Execute(decimal a, decimal b)
        {
            decimal result;
            double sqrt = Math.Sqrt(Convert.ToDouble(b));
            result = a * Convert.ToDecimal(sqrt);
            return result;
        }
    }
}
