using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public class Worker : Employee
    {
        public string NickName { get; set; }

        public void DoWork()
        {
            Console.WriteLine($"{NickName} делает работу");
        }
    }
}
