using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace KYHProject.ControllersLibrary
{
    public interface IController
    {
        public void Create();
        public void Show();
        public void Update();
        public void Delete();
    }
}
