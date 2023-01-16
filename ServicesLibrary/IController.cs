using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
