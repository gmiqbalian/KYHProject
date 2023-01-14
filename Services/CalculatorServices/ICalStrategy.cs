using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHProject.Services
{
    public interface ICalStrategy
    {
        public decimal Execute(decimal a, decimal b);
    }
}