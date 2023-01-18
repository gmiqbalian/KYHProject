using DBContextLibrary.Data;
using KYHProject.ControllersLibrary;
using KYHProject.Services;
using ServicesLibrary.ShapeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllersLibrary
{
    public class ControllerFactory
    {
        private IController _controller;
        private AppDbContext _dbContext;        
        public ControllerFactory(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IController GetController(string name)
        {
            switch (name)
            {
                case "shape":
                    _controller = new ShapeController
                        (_dbContext, new ShapeServices());
                    break;
                case "calculator":                    
                    _controller = new CalculatorController
                        (_dbContext, new CalculatorServices());
                    break;
                default:
                    break;
            }
            return _controller;
        }
    }
}
