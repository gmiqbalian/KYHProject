using Calculator;
using ControllersLibrary;
using DBContextLibrary.Data;
using GameApp;
using KYHProject.ControllersLibrary;
using Microsoft.EntityFrameworkCore;
using ShapeApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHProject
{
    public class MenuFactory
    {
        private readonly AppDbContext _dbContext;
        private readonly ControllerFactory _controller;                
        public MenuFactory(AppDbContext dbContext,ControllerFactory controller)
        {
            _dbContext = dbContext;
            _controller = controller;
        }        
        public void GetMenu(string name)
        {
            switch (name)
            {
                case "shape":
                    var shapeApp = new ShapeMenu
                        (_controller.GetController("shape"));
                    shapeApp.ShowShapeMenu();
                    break;
                case "calculator":
                    var calApp = new CalculatorMenu
                    (_controller.GetController("calculator"));
                    calApp.ShowCalulatorMenu();
                    break;
                case "game":
                    var gameApp = new GameMenu(
                        new GameController(_dbContext));
                    gameApp.ShowGameMenu();
                    break;
                default:
                    break;
            }
        }
    }
}
