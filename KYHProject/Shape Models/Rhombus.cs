using KYHProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHProject.App_Models
{
    public class Rhombus : Shape 
    { 
        public override double GetPerimeter() 
        { 
            return Base * 4; 
        } 
    }
}