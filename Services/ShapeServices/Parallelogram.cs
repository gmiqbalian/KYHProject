namespace ServicesLibrary.ShapeFactory
{
    public class Parallelogram : Shape
    {
        public override decimal GetPerimeter()
        {
            return b * 2 + a * 2;
        }
    }

}
