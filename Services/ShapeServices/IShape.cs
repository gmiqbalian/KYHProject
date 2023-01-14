using KYHProject.Enums;
using KYHProject.Models;

namespace ServicesLibrary.ShapeFactory
{
    public interface IShape
    {
        public decimal GetArea();
        public decimal GetPerimeter();
    }
}