using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHProject.Services
{
    public class CalStrategy : ICalStrategy
    {
        private readonly decimal _a;
        private readonly decimal _b;

        public CalStrategy(decimal a, decimal b)
        {
            _a = a;
            _b = b;
        }
        public decimal Addition()
        {
            return _a + _b;
        }

        public decimal Division()
        {
            return _a / _b;
        }

        public decimal Modulus()
        {
            return _a % _b;
        }

        public decimal Multiplication()
        {
            return _a * _b;
        }
        public decimal Subtraction()
        {
            return _a - _b;
        }

        public decimal SquareRoot()
        {
            var input = Convert.ToDouble(_a);
            return Convert.ToDecimal(Math.Sqrt(input));
        }

    }
}
