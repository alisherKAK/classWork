using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespacesLesson15_01_19
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            try
            {
                user.Registration();
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                user.Registration();
            }
        }
    }
}
