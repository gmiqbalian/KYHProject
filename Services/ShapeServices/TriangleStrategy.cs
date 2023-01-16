using KYHProject.Models;

namespace ServicesLibrary.ShapeServices
{
    public class TriangleStrategy : IShapeStrategy
    {
        //public AreaPerimeter GetAreaPerimeter(decimal b, decimal h, decimal a, decimal c)
        //{
        //    var triangle = new AreaPerimeter();
        //    triangle.Area = h * b;
        //    triangle.Perimeter = a+b+c;

        //    return triangle;
        //}

        //public AreaPerimeter GetAreaPerimeter(ShapeResult forShape)
        //{
        //    var triangle = new AreaPerimeter();
        //    triangle.Area = forShape.Height * forShape.Base;
        //    triangle.Perimeter = forShape.ValueA + forShape.Base + forShape.ValueC;

        //    return triangle;
        //}
        public void GetAreaPerimeter(ShapeResult forShape)
        {
            forShape.Area = forShape.Height * forShape.Base;
            forShape.Perimeter = forShape.ValueA + forShape.Base + forShape.ValueC;
        }        
    }

}
