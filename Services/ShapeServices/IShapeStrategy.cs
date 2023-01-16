using KYHProject.Enums;
using KYHProject.Models;
using ServicesLibrary.ShapeServices;

namespace ServicesLibrary.ShapeServices
{
    public interface IShapeStrategy
    {
        //AreaPerimeter GetAreaPerimeter(decimal b, decimal h, decimal a, decimal c);
        void GetAreaPerimeter(ShapeResult forShape);
    }
}