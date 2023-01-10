using KYHProject.Models;

namespace KYHProject.App_Models
{
    public class Parallelogram : Shape 
    {
        public override double GetPerimeter()
        { 
            return Base * 2 + ValueA * 2;
        } 
    }
}