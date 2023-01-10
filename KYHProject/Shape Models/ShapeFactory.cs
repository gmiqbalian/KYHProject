using KYHProject.Enums;
using KYHProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHProject.App_Models
{
    public class ShapeFactory
    {
        private Shape _shape {get; set;}
        public Shape GetShape(EnumShapeType shapeType)
        {
            switch (shapeType)
            {
                case EnumShapeType.Rectangle:
                    _shape = new Rectangle();                
                    break;
                case EnumShapeType.Parallelogram:
                    _shape = new Parallelogram();
                    break;
                case EnumShapeType.Triangle:
                    _shape = new Triangle();
                    break;
                case EnumShapeType.Rhombus:
                    _shape = new Rhombus();
                    break;
                default:
                    break;
            }

            return _shape;
        }
    }
}
