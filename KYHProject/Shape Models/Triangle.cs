using KYHProject.Models;

namespace KYHProject.App_Models
{
    public class Triangle : Shape 
    {        
        public override double GetArea()
        {
            return (Height * Base) / 2;            
        }
        public override double GetPerimeter()
        {
            return Base + ValueA + ValueC;
        }
    }
}