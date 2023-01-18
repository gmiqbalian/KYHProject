using ConsoleTables;
using DBContextLibrary.Data;
using InputClassLibrary;
using KYHProject.Models;
using KYHProject.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace KYHProject.ControllersLibrary
{
    public class CalculatorController : IController
    {
        private AppDbContext _dbContext;
        private CalculatorServices _calServices;
        public CalculatorController(AppDbContext dbContext, CalculatorServices calServices)
        {
            _dbContext = dbContext;
            _calServices = calServices;            
        }
        public void Create()
        {
            Console.Clear();

            var newCalculation = new CalculationResult();
            newCalculation.CreatedOn = DateTime.Now;

            var sel = ShowCalculationStrategies();
            if (sel == 0) return;

            SetCalculationStrategy(newCalculation, sel);

            Console.Write("\nEnter number 1: ");
            newCalculation.a = Input.GetDecimal();

            Console.Write("\nEnter number 2: ");
            newCalculation.b = Input.GetDecimal();

            newCalculation.Result = _calServices.
                ExecuteStrategy(newCalculation.a, newCalculation.b);

            var text = ($"\nYour result is {newCalculation.a} " +
                $"{newCalculation.Operator} " +
                $"{newCalculation.b} " +
                $"= {newCalculation.Result}");
            Input.WriteYellow(text);

            _dbContext.CalculationResults.Add(newCalculation);
            _dbContext.SaveChanges();
            Input.PressAnyKey();
        }
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("\nPrevious Calculations");
            var calculationsList = GetList();
            if (calculationsList == null)
                return;

            var table = new ConsoleTable(
                    "Id",
                    "Value a",
                    "Operator",
                    "Value b",
                    "Result");

            foreach (var c in calculationsList)
                table.AddRow(c.Id,
                    c.a,
                    c.Operator,
                    c.b,
                    c.Result);

            Console.WriteLine(table);            
        }
        public void Update()
        {
            var calculationsList = GetList();
            if (calculationsList == null)
                return;

            Show();

            var idList = _dbContext.
                CalculationResults.
                Select(c => c.Id).ToList();

            var calToUpdateId = Input.CheckId(idList);

            var calToUpdate = _dbContext.CalculationResults.
                First(c => c.Id == calToUpdateId);

            var sel = ShowCalculationStrategies();
            if (sel == 0) return;

            SetCalculationStrategy(calToUpdate, sel);

            Console.Write("\nEnter number 1: ");
            calToUpdate.a = Input.GetDecimal();

            Console.Write("\nEnter number 2: ");
            calToUpdate.b = Input.GetDecimal();

            calToUpdate.Result = _calServices.
                ExecuteStrategy(calToUpdate.a, calToUpdate.b);

            var text = ($"\nYour new result is {calToUpdate.a} " +
                $"{calToUpdate.Operator} " +
                $"{calToUpdate.b} " +
                $"= {calToUpdate.Result}");
            Input.WriteYellow(text);

            _dbContext.SaveChanges();
            Input.WriteGreen("\nSucessfully updated the result!");
            Input.PressAnyKey();
        }
        public void Delete()
        {
            var calculationsList = GetList();
            if (calculationsList == null)
                return;

            Show();

            var idList = _dbContext.
                CalculationResults.
                Select(c => c.Id).ToList();

            var calToDeleteId = Input.CheckId(idList);

            var calToDelete = _dbContext.CalculationResults.
                First(c => c.Id == calToDeleteId);

            _dbContext.CalculationResults.Remove(calToDelete);
            _dbContext.SaveChanges();

            Input.WriteRed("\nSucessfully deleted the result!");
            Input.PressAnyKey();
        }
        private void SetCalculationStrategy(CalculationResult forCalculation, int sel)
        {
            switch (sel)
            {
                case 1:
                    _calServices.
                        SetStrategy(new AdditionStrategy());
                    forCalculation.Operator = '+';
                    break;
                case 2:
                    _calServices.
                        SetStrategy(new SubtractionStrategy());
                    forCalculation.Operator = '-';
                    break;
                case 3:
                    _calServices.
                        SetStrategy(new MultiplicationStrategy());
                    forCalculation.Operator = '*';
                    break;
                case 4:
                    _calServices.
                        SetStrategy(new DivisionStrategy());
                    forCalculation.Operator = '/';
                    break;
                case 5:
                    _calServices.
                        SetStrategy(new ModulusStrategy());
                    forCalculation.Operator = '%';
                    break;
                default:
                    break;
            }
        }
        public int ShowCalculationStrategies()
        {
            Console.WriteLine("\nChoose calculation opretaor\n");

            Console.WriteLine("1: + Addition");
            Console.WriteLine("2: - Subtraction");
            Console.WriteLine("3: * Multiplication");
            Console.WriteLine("4: / Division");
            Console.WriteLine("5: % Modulus");
            Console.WriteLine("0: Exit");

            return Input.GetSelFromRange(5);            
        }
        private List<CalculationResult> GetList()
        {
            var calculationsList = _dbContext.
                CalculationResults.
                ToList();
            
            if (calculationsList.Count() == 0)
            {
                Input.WriteYellow("\nThere is no record to show.");
                return null;
            }

            return calculationsList;
        }
    }
}
