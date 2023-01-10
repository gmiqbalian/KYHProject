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
        private ShapeController _shapeController;
        public ResultController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _shapeController = new ShapeController(dbContext);
        }
        public void Create()
        {
            var newResult = new Result();

            newResult.CreatedOn = DateTime.Now;
            newResult.Shape = _shapeController.Create();

            _dbContext.Results.Add(newResult);
            _dbContext.SaveChanges();
        }
    }
}
