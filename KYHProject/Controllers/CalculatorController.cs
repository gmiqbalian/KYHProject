using ConsoleTables;
using InputClassLibrary;
using KYHProject.Data;
using KYHProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHProject.Controllers
{
    public class CalculatorController
    {
        private AppDbContext _dbContext;
        public CalculatorController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create()
        {
            var newCalculator = new Calculator();

            newCalculator.CreatedOn = DateTime.Now;

            Console.Write("\nEnter number 1: ");
            newCalculator.Number1 = Input.GetDecimal();

            Console.Write("\nEnter operator (+, -, *, /, √, %): ");
            newCalculator.Operator = Convert.ToChar(Console.ReadLine());

            Console.Write("\nEnter number 2: ");
            newCalculator.Number2 = Input.GetDecimal();

            Console.WriteLine(newCalculator.Result);

            _dbContext.Calculators.Add(newCalculator);
            _dbContext.SaveChanges();
        }
        public void Show()
        {
            var calList = _dbContext.Calculators.ToList();
            var table = new ConsoleTable("Id", "Number1", "Operator", "Number2", "Result");
            foreach (var c in calList)
            {
                table.AddRow(c.CalculatorId, c.Number1, c.Operator, c.Number2, c.Result);
            }

            Console.WriteLine(table);            
        }
        public void Update()
        {
            Show();

            Console.Write("\nEnter calculation Id to update: ");
            var calToUpdateId = Input.GetInt();

            var calToUpdate = _dbContext.Calculators.
                First(c => c.CalculatorId == calToUpdateId);

            Console.Write("\nEnter number 1: ");
            calToUpdate.Number1 = Input.GetDecimal();
            
            Console.Write("\nEnter operator (+, -, *, /, √, %): ");
            calToUpdate.Operator = Convert.ToChar(Console.ReadLine());
            
            Console.Write("\nEnter number 2: ");
            calToUpdate.Number2 = Input.GetDecimal();

            Console.WriteLine(calToUpdate.Result);
        }
        public void Delete()
        {
            Show();

            Console.Write("\nEnter calculation Id to delete: ");
            var calToDeleteId = Input.GetInt();

            var calToDelete = _dbContext.Calculators.
                First(c=> c.CalculatorId == calToDeleteId);

            _dbContext.Calculators.Remove(calToDelete);
            _dbContext.SaveChanges();
        }
    }
}
