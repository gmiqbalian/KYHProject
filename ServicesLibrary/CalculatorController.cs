﻿using ConsoleTables;
using DBContextLibrary.Data;
using InputClassLibrary;
using KYHProject.Models;
using KYHProject.Services;
using System.Reflection.Metadata.Ecma335;

namespace KYHProject.ControllersLibrary
{
    public class CalculatorController : IController
    {
        private AppDbContext _dbContext;
        private CalStrategy _calStrategy;
        public CalculatorController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _calStrategy = new CalStrategy();
        }

        public void Create()
        {
            var newCalculation = new CalculationResult();
            newCalculation.CreatedOn = DateTime.Now;
                        
            SetCalculationStrategy(newCalculation);
            
            Console.Write("\nEnter number 1: ");
            newCalculation.a = Input.GetDecimal();

            Console.Write("\nEnter number 2: ");
            newCalculation.b = Input.GetDecimal();

            newCalculation.Result = _calStrategy.
                ExecuteStrategy(newCalculation.a, newCalculation.b);
            
            Console.WriteLine($"\nYour result is {newCalculation.a} " +
                $"{newCalculation.Operator} " +
                $"{newCalculation.b} " +
                $"= {newCalculation.Result}");

            _dbContext.CalculationResults.Add(newCalculation);
            _dbContext.SaveChanges();
        }
        public void Show()
        {
            var calList = _dbContext.CalculationResults.ToList();
            var table = new ConsoleTable(
                "Id", 
                "Value a", 
                "Operator", 
                "Value b", 
                "Result");

            foreach (var c in calList)            
                table.AddRow(c.Id, 
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

            var calToUpdate = _dbContext.CalculationResults.
                First(c => c.Id == calToUpdateId);

            SetCalculationStrategy(calToUpdate);

            Console.Write("\nEnter number 1: ");
            calToUpdate.a = Input.GetDecimal();

            Console.Write("\nEnter number 2: ");
            calToUpdate.b = Input.GetDecimal();

            calToUpdate.Result = _calStrategy.
                ExecuteStrategy(calToUpdate.a, calToUpdate.b);

            Console.WriteLine($"\nYour new result is {calToUpdate.a} " +
                $"{calToUpdate.Operator} " +
                $"{calToUpdate.b} " +
                $"= {calToUpdate.Result}");

            _dbContext.SaveChanges();            
        }
        public void Delete()
        {
            Show();

            Console.Write("\nEnter calculation Id to delete: ");
            var calToDeleteId = Input.GetInt();

            var calToDelete = _dbContext.CalculationResults.
                First(c=> c.Id == calToDeleteId);

            _dbContext.CalculationResults.Remove(calToDelete);
            _dbContext.SaveChanges();
        }
        private void SetCalculationStrategy(CalculationResult forCalculation)
        {
            Console.WriteLine("\nChoose calculation opretaor\n");

            Console.WriteLine("1: + Addition");
            Console.WriteLine("2: - Subtraction");
            Console.WriteLine("3: * Multiplication");
            Console.WriteLine("4: / Division");
            Console.WriteLine("5: % Modulus");
            Console.WriteLine("0: Exit");
                        
            var sel = Input.GetSelFromRange(5);
                        
            switch (sel)
            {
                case 1:
                    _calStrategy.
                        SetStrategy(new AdditionStrategy());
                    forCalculation.Operator = '+';
                    break;
                case 2:
                    _calStrategy.
                        SetStrategy(new SubtractionStrategy());
                    forCalculation.Operator = '-';
                    break;
                case 3:
                    _calStrategy.
                        SetStrategy(new MultiplicationStrategy());
                    forCalculation.Operator = '*';
                    break;
                case 4:
                    _calStrategy.
                        SetStrategy(new DivisionStrategy());
                    forCalculation.Operator = '/';
                    break;
                case 5:
                    _calStrategy.
                        SetStrategy(new ModulusStrategy());
                    forCalculation.Operator = '%';
                    break;
                default:
                    break;
            }
        }
    }
}
