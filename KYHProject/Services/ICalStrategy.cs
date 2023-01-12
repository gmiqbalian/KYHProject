using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHProject.Services
{
    public interface ICalStrategy
    {
        public decimal Addition();
        public decimal Subtraction();
        public decimal Division();
        public decimal Multiplication();
        public decimal Modulus();
        public decimal SquareRoot();
    }
}