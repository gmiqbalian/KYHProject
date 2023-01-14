using KYHProject.Enums;
using KYHProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.ShapeFactory
{
    public abstract class ShapeFactory
    {
        public abstract Shape GetShape(int shapeType);        
    }
}
