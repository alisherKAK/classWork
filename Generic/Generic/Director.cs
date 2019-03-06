using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public class Director : Employee, IManager
    {
        public string FullName { get; set; }

        public void DoStaff()
        {
            Console.WriteLine($"{FullName} управляет работой");
        }
    }
}
