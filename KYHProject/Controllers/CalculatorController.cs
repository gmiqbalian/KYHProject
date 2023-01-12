using ConsoleTables;
using InputClassLibrary;
using KYHProject.Data;
using KYHProject.Models;
using KYHProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHProject.Controllers
{
    public class CalculatorController : IController
    {
        private AppDbContext _dbContext;
        private CalStrategy _calStrategy;
        public CalculatorController(AppDbContext dbContext)
        {
            _dbContext = dbContext;            
        }
        public void Create()
        {
            var newCalculation = new Calculation();
            newCalculation.CreatedOn = DateTime.Now;

            Console.Write("\nEnter number 1: ");
            newCalculation.a = Input.GetDecimal();

            Console.Write("\nChoose an operator\n(+ , - , / , * , %): ");
            newCalculation.Operator = Convert.ToChar(Console.ReadLine());

            Console.Write("\nEnter number 2: ");
            newCalculation.b = Input.GetDecimal();

            _calStrategy = new CalStrategy(newCalculation.a, newCalculation.b);
            GetCalculationStrategy(newCalculation);

            Console.WriteLine($"{newCalculation.a} " +
                $"{newCalculation.Operator} " +
                $"{newCalculation.b} " +
                $"= {newCalculation.Result}");

            _dbContext.Calculators.Add(newCalculation);
            _dbContext.SaveChanges();
        }

        public void Show()
        {
            var calList = _dbContext.Calculators.ToList();
            var table = new ConsoleTable("Id", "Value a", "Operator", "Value b", "Result");

            foreach (var c in calList)            
                table.AddRow(c.CalculationId, 
                    c.a, 
                    c.Operator, 
                    c.b, 
                    c.Result);

            Console.WriteLine(table);
        }
        public void Update()
        {
            Show();

            Console.Write("\nEnter calculation Id to update: ");
            var calToUpdateId = Input.GetInt();

            var calToUpdate = _dbContext.Calculators.
                First(c => c.CalculationId == calToUpdateId);

            Console.Write("\nEnter number 1: ");
            calToUpdate.a = Input.GetDecimal();
            
            Console.Write("\nEnter operator (+, -, *, /, √, %): ");
            calToUpdate.Operator = Convert.ToChar(Console.ReadLine());
            _calStrategy = new CalStrategy(calToUpdate.a, calToUpdate.b);
            GetCalculationStrategy(calToUpdate);

            Console.Write("\nEnter number 2: ");
            calToUpdate.b = Input.GetDecimal();

            Console.WriteLine($"{calToUpdate.a} " +
                $"{calToUpdate.Operator} " +
                $"{calToUpdate.b} " +
                $"= {calToUpdate.Result}");
            
        }
        public void Delete()
        {
            Show();

            Console.Write("\nEnter calculation Id to delete: ");
            var calToDeleteId = Input.GetInt();

            var calToDelete = _dbContext.Calculators.
                First(c=> c.CalculationId == calToDeleteId);

            _dbContext.Calculators.Remove(calToDelete);
            _dbContext.SaveChanges();
        }
        private void GetCalculationStrategy(Calculation newCalculation)
        {
            switch (newCalculation.Operator)
            {
                case '+':
                    newCalculation.Result
                        = _calStrategy.Addition();
                    break;
                case '-':
                    newCalculation.Result
                        = _calStrategy.Subtraction();
                    break;
                case '/':
                    newCalculation.Result
                        = _calStrategy.Division();
                    break;
                case '*':
                    newCalculation.Result
                        = _calStrategy.Multiplication();
                    break;
                case '%':
                    newCalculation.Result
                        = _calStrategy.Modulus();
                    break;
                default:
                    break;
            }
        }
    }
}
