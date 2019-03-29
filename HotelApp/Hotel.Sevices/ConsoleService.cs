using Hotel.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Sevices
{
    public class ConsoleService : IReporter, IReader 
    {
        public string Read()
        {
            return Console.ReadLine().Trim();
        }

        public void Send(string text)
        {
            Console.WriteLine(text);
        }

        public void Send()
        {
            Console.WriteLine();
        }
    }
}
