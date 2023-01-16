using KYHProject.Enums;
using KYHProject.Models;
using System.Reflection.Metadata;

namespace ServicesLibrary.ShapeServices
{
    public class ParallelogramStrategy : IShapeStrategy
    {

        //public AreaPerimeter GetAreaPerimeter(decimal b, decimal h, decimal a, decimal c)
        //{
        //    var parallelogram = new AreaPerimeter();
        //    parallelogram.Area = h * b;
        //    parallelogram.Perimeter = 2 * b + 2 * a;

        //    return parallelogram;
        //}

        //public AreaPerimeter GetAreaPerimeter(ShapeResult forShape)
        //{
        //    var parallelogram = new AreaPerimeter();
        //    parallelogram.Area = forShape.Height * forShape.Base;
        //    parallelogram.Perimeter = 2 * forShape.Base + 2 * forShape.ValueA;

        //    return parallelogram;
        //}
        public void GetAreaPerimeter(ShapeResult forShape)
        {
            forShape.Area = forShape.Height * forShape.Base;
            forShape.Perimeter = 2 * forShape.Base + 2 * forShape.ValueA;
        }
    }
}