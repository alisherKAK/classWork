using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWork05_04_19
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();
            account.Propertychanged += (sender, property) =>
            {
                Console.WriteLine($"{property.Name} был изменен");
            };

            account.Sum = 0;
        }
    }
}
