using KYHProject.Models;

namespace ServicesLibrary.ShapeServices
{
    public class RhombusStrategy : IShapeStrategy
    {       
        public void GetAreaPerimeter(ShapeResult forShape)
        {
            forShape.Area = forShape.Height * forShape.Base;
            forShape.Perimeter = 4 * forShape.Base;
        }
    }

}
