using KYHProject.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace KYHProject.Models
{
    public class ShapeResult
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public EnumShapeType Type { get; set; }
        public decimal Base { get; set; }
        public decimal Height { get; set; }
        public decimal ValueA { get; set; }   
        public decimal ValueC { get; set; }
        public decimal Area { get; set; }
        public decimal Perimeter { get; set; }
    }
}
