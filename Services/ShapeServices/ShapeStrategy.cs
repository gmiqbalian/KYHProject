using KYHProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.ShapeServices
{
    public class ShapeStrategy
    {
        private IShapeStrategy _strategy;

        public void SetStrategy(IShapeStrategy strategy)
        {
            _strategy = strategy;
        }

        //public AreaPerimeter ExecuteStrategy(decimal b, decimal h, decimal a, decimal c)
        //{
        //    return _strategy.GetAreaPerimeter(b, h, a, c );
        //}
        //public AreaPerimeter ExecuteStrategy(ShapeResult forShape)
        //{
        //    return _strategy.GetAreaPerimeter(forShape);
        //}
        public void ExecuteStrategy (ShapeResult forShape)
        {
            _strategy.GetAreaPerimeter(forShape);
        }
    }
}
