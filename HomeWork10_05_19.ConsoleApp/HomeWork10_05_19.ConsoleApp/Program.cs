using HomeWork10_05_19.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10_05_19.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Migrations.UpdateDatabase();
            Console.Clear();

            Console.ReadLine();
        }
    }
}
