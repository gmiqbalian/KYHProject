using KYHProject.Data;
using KYHProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHProject.Controllers
{
    public class ResultController
    {
        private AppDbContext _dbContext;
        private ShapeController _controller;
        public ResultController(AppDbContext dbContext, string type)
        {
            _dbContext = dbContext;
            if (type == "shape")
                _controller = new ShapeController(dbContext);
            //else if (type == "calculator")
            //    _controller = new CalculatorController(dbContext);
            //else if (type == "game")
            //    _controller = new GameController(dbContext);
        }
        public void Create()
        {
            var newResult = new Result();

            newResult.CreatedOn = DateTime.Now;
            newResult.Shape = _controller.Create();

            _dbContext.Results.Add(newResult);
            _dbContext.SaveChanges();
        }
        public void Show()
        {

        }
        public void Update()
        {

        }
        public void Delete()
        {

        }
    }
}
