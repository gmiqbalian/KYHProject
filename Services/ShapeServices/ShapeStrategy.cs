using KYHProject.Enums;
using KYHProject.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace ServicesLibrary.ShapeServices
{
    public class ShapeStrategy
    {
        private IShapeStrategy _strategy;        
        public void SetStrategy(ShapeResult _forShape)
        {
            switch (_forShape.Type)
            {
                case EnumShapeType.Rectangle:
                    _strategy = new RectangleStrategy();
                    break;
                case EnumShapeType.Parallelogram:
                    _strategy = new ParallelogramStrategy();
                    break;
                case EnumShapeType.Triangle:
                    _strategy = new TriangleStrategy();
                    break;
                case EnumShapeType.Rhombus:
                    _strategy = new RhombusStrategy();
                    break;
                default:
                    break;
            }
        }
        public void ExecuteStrategy(ShapeResult _forShape)
        {
            _strategy.GetAreaPerimeter(_forShape);
        }
    }
}
