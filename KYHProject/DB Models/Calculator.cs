using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHProject.Models
{
    public class Calculator
    {
        public int CalculatorId {get; set;}
        public DateTime CreatedOn { get; set;}
        public decimal Number1 { get; set; }
        public decimal Number2 { get; set; }
        public char Operator { get; set; }
        public decimal Result { get { return GetResult(); } set { } }
        public List<Result> Results { get; set; } = new List<Result>();

        public decimal GetResult()
        {
            decimal result = 0;

            switch (Operator)
            {
                case '+':
                    result = Number1 + Number2;
                    break;
                case '-':
                    result = Number1 - Number2;
                    break;
                case '*':
                    result = Number1 * Number2;
                    break;
                case '/':
                    result = Number1 / Number2; 
                    break;
                case '%':
                    result = Number1 % Number2;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
