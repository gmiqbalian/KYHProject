using KYHProject.App_Models;
using KYHProject.Enums;
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
        public DateTime CreatedOn { get; set; }
        public decimal Base { get; set; }
        public decimal Height { get; set; }
        public decimal ValueA { get; set; }
        public decimal ValueC { get; set; }
        public EnumShapeType Type { get; set; }
        public decimal Area 
        { 
            get { return GetArea(); } 
            set { } 
        }
        public decimal Perimeter 
        { 
            get { return GetPerimeter(); } 
            set { } 
        }
        public virtual decimal GetArea()
        {
            return Base * Height;
        }
        public virtual decimal GetPerimeter()
        {
            return Base * 2 + Height * 2;            
        }
    }
}
