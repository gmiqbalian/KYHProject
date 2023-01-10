using KYHProject.App_Models;
using KYHProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHProject.Models
{
    public class Shape : IShape
    {
        public int ShapeId { get; set; }
        public double Base { get; set; }
        public double Height { get; set; }
        public double ValueA { get; set; }
        public double ValueC { get; set; }
        public EnumShapeType Type { get; set; }
        public double Area 
        { 
            get { return GetArea(); } 
            set { } 
        }
        public double Perimeter 
        { 
            get { return GetPerimeter(); } 
            set { } 
        }
        public List<Result> Results { get; set; } = new List<Result> ();

        public virtual double GetArea()
        {
            return Base * Height;
        }

        public virtual double GetPerimeter()
        {
            return Base * 2 + Height * 2;            
        }
    }
}
