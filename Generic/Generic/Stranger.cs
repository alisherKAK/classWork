using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public class Stranger : IManager
    {
        public void DoStaff()
        {
            Console.WriteLine("Мутит какую-то хрень и вообще не наш сотрудник");
        }
    }
}
