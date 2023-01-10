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
        [Key]
        public int CalculatorId {get; set;}
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public string Sign { get; set; }
    }
}
