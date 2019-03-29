using Hotel.Services.Abstract;
using Hotel.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IReporter reporter = new ConsoleService();
            IReader reader = new ConsoleService();

            SetInformation setInformation = new SetInformation(reporter, reader);

            setInformation.SetEmail();
        }
    }
}
