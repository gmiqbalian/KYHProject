using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHProject.Models
{
    public class Shape
    {
        public int ShapeId { get; set; }
        public double Base { get; set; }
        public double Height { get; set; }
        public double? Side { get; set; }
        public EnumShapeType Type { get; set; }
        public double Area { get; set; }
        public double Circumference { get; set; }

    }
}
