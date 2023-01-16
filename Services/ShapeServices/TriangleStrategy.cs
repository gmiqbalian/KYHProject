using KYHProject.Models;

namespace ServicesLibrary.ShapeServices
{
    public class TriangleStrategy : IShapeStrategy
    {     
        public void GetAreaPerimeter(ShapeResult forShape)
        {
            forShape.Area = (forShape.Height * forShape.Base) / 2;
            forShape.Perimeter = forShape.ValueA + forShape.Base + forShape.ValueC;
        }
    }

}
