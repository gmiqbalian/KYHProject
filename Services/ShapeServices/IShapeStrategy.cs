using KYHProject.Models;

namespace ServicesLibrary.ShapeServices
{
    public interface IShapeStrategy
    {        
        void GetAreaPerimeter(ShapeResult forShape);
    }
}