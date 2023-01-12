using InputClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHProject.Models
{
    public class Calculation
    {
        public int CalculationId {get; set;}
        public DateTime CreatedOn { get; set;}
        public decimal a { get; set; }
        public decimal b { get; set; }
        public char Operator { get; set; }
        public decimal Result { get; set; }        
    }

}

