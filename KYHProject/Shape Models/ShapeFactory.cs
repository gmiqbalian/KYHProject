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
        public Shape GetShape(int shapeType)
        {
            switch (shapeType)
            {
                case 1:
                    _shape = new Rectangle();                    
                    break;
                case 2:
                    _shape = new Parallelogram();                    
                    break;
                case 3:
                    _shape = new Triangle();                    
                    break;
                case 4:
                    _shape = new Rhombus();                    
                    break;
                default:
                    break;
            }

            return _shape;
        }
    }
}
