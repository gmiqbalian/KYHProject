﻿using KYHProject.Models;

namespace ServicesLibrary.ShapeServices
{
    public class ParallelogramStrategy : IShapeStrategy
    {
        public void GetAreaPerimeter(ShapeResult forShape)
        {
            forShape.Area = forShape.Height * forShape.Base;
            forShape.Perimeter = 2 * forShape.Base + 2 * forShape.ValueA;
        }
    }
}