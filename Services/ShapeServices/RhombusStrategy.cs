using KYHProject.Enums;
using KYHProject.Models;
using System.Reflection.Metadata;

namespace ServicesLibrary.ShapeServices
{
    public class RhombusStrategy : IShapeStrategy
    {
        //public AreaPerimeter GetAreaPerimeter(decimal b, decimal h, decimal a, decimal c)
        //{
        //    var rhombus = new AreaPerimeter();
        //    rhombus.Area = h * b;
        //    rhombus.Perimeter = 4 * b;

        //    return rhombus;
        //}
        //public AreaPerimeter GetAreaPerimeter(ShapeResult forShape)
        //{
        //    var rhombus = new AreaPerimeter();
        //    rhombus.Area = forShape.Height * forShape.Base;
        //    rhombus.Perimeter = 4 * forShape.Base;

        //    return rhombus;
        //}
        public void GetAreaPerimeter(ShapeResult forShape)
        {
            forShape.Area = forShape.Height * forShape.Base;
            forShape.Perimeter = 4 * forShape.Base;
        }
    }

}
