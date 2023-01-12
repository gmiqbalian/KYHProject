using KYHProject.Enums;
using KYHProject.Models;

namespace KYHProject.App_Models
{
    public interface IShape
    {
        public decimal GetArea();
        public decimal GetPerimeter();
    } 
    public class Rectangle : Shape
    {
        
    }
    public class Parallelogram : Shape
    {
        public decimal ValueA { get; set; }
        public override decimal GetPerimeter()
        {
            return Base * 2 + ValueA * 2;
        }
    }
    public class Rhombus : Shape
    {
        public override decimal GetPerimeter()
        {
            return Base * 4;
        }
    }
    public class Triangle : Shape
    {
        public decimal ValueA { get; set; }
        public decimal ValueC { get; set; }
        public override decimal GetArea()
        {
            return (Height * Base) / 2;
        }
        public override decimal GetPerimeter()
        {
            return Base + ValueA + ValueC;
        }
    }
}