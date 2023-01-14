using KYHProject.Enums;
using KYHProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.ShapeFactory
{
    public class Shape : IShape
    {
        public decimal b { get; set; }
        public decimal h { get; set; }
        public decimal a { get; set; }
        public decimal c { get; set; }
        public EnumShapeType Type { get; set; }        

        public virtual decimal GetArea()
        {
            return b * h;
        }

        public virtual decimal GetPerimeter()
        {
            return 2 * b + 2 * h;
        }
    }

}
