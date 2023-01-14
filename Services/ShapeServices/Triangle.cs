namespace ServicesLibrary.ShapeFactory
{
    public class Triangle : Shape
    {
        public override decimal GetArea()
        {
            return h * b / 2;
        }
        public override decimal GetPerimeter()
        {
            return b + a + c;
        }
    }

}
