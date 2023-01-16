using KYHProject.Enums;
using KYHProject.Models;

namespace ServicesLibrary.ShapeServices
{
    public class RectangleStrategy : IShapeStrategy
    {

        //public AreaPerimeter GetAreaPerimeter(decimal b, decimal h, decimal a, decimal c)
        //{
        //    var rectangle = new AreaPerimeter();
        //    rectangle.Area = h*b;
        //    rectangle.Perimeter = 2 * b + 2 * h;

        //    return rectangle;
        //}
        //public AreaPerimeter GetAreaPerimeter(ShapeResult forShape)
        //{
        //    var rectangle = new AreaPerimeter();
        //    rectangle.Area = forShape.Height * forShape.Base;
        //    rectangle.Perimeter = 2 * forShape.Base + 2 * forShape.Height;

        //    return rectangle;
        //}
        public void GetAreaPerimeter(ShapeResult forShape)
        {
            forShape.Area = forShape.Height* forShape.Base;
            forShape.Perimeter = 2 * forShape.Base + 2 * forShape.Height;
        }
    }

}
